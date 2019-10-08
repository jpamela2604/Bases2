using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PAGO_CHEQUE : Form
    {
        public PAGO_CHEQUE()
        {
            InitializeComponent();
        }

        OracleConnection ora;
        OracleDataAdapter adaptador;
        OracleCommand comando;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PAGO_CHEQUE_Load(object sender, EventArgs e)
        {
            this.btn_cobrar.Enabled = false;
            ora = new OracleConnection(
                "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
                "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
                "USER ID=" + Properties.Settings.Default.usuario_db + ";"
                );
        }

        private void btn_verif_Click(object sender, EventArgs e)
        {
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT firma FROM CLIENTE WHERE codigo_cliente = (SELECT cliente FROM CLIENTE_CUENTA WHERE cuenta = :cuenta)";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                ABC_CLIENTE b = new ABC_CLIENTE();
                byte[] firma = (byte[])(dr["firma"]);
                String ruta = b.convert_blob_to_image(firma, "firma");
                pic_firma.Image = Image.FromFile(ruta);
                this.btn_cobrar.Enabled = true;
            }catch(Exception ex)
            {
                this.btn_cobrar.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Debe ingresar un numero de cuenta valido");
            }
            finally
            {
                ora.Close();
            }           
        }

        private void btn_cobrar_Click(object sender, EventArgs e)
        {
            ora.Open();            
            comando = new OracleCommand();
            comando.Connection = ora;
            OracleTransaction trans = ora.BeginTransaction();
            comando.Transaction = trans;
            try
            {
                //VERIFICACION INICIAL DEL CHEQUE
                comando.CommandText = "select estado_cheque from cheque_local where codigo_cheque = :cheque";
                comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                if(dr["estado_cheque"] != null)
                {
                    Int32 estado_chequera = Convert.ToInt32(dr["estado_cheque"]);
                    String mensaje = "";
                    if(estado_chequera == 5)
                    {
                        mensaje = "rechazado";
                    }else if(estado_chequera == 4)
                    {
                        mensaje = "cobrado";
                    }else if(estado_chequera == 3)
                    {
                        mensaje = "robado";
                    }else if(estado_chequera == 2)
                    {
                        mensaje = "extraviado";
                    }
                    System.Windows.Forms.MessageBox.Show("Error el cheque aparece: "+mensaje);
                    return;
                }
                
                //VERIFICAR EL CHEQUE
                comando.CommandText = "SELECT * FROM chequera WHERE cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                dr = comando.ExecuteReader();
                dr.Read();      

                //CHEQUE PERTENEZCA A CUENTA
                if (Convert.ToInt32(dr["cuenta"]) != Convert.ToInt32(txt_nocuenta.Text))
                {
                    System.Windows.Forms.MessageBox.Show("El cheque no pertenece a la cuenta asociada");
                    //RECHAZAR CHEQUE
                    return;
                }

                //CHEQUE PERTENEZCA A CHEQUERA
                if (Convert.ToInt32(dr["codigo_chequera"]) != Convert.ToInt32(txt_nocuenta.Text))
                {
                    System.Windows.Forms.MessageBox.Show("El cheque no pertenece a la chequera ");
                    //RECHAZAR CHEQUE
                    return;
                }

                //VERIFICA EL SALDO
                comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                dr = comando.ExecuteReader();
                dr.Read();
                Int32 saldo = Convert.ToInt32(dr["saldo_disponible"]);
                Int32 monto = Convert.ToInt32(txt_monto.Text);
                if (saldo < monto)
                {
                    System.Windows.Forms.MessageBox.Show("Saldo Insuficiente");
                    //RECHAZAR CHEQUE
                    return;
                }

                //SE DEBITA DE LA CUENTA
                comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible - :monto WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToInt32(txt_monto.Text);
                comando.ExecuteNonQuery();
                //CHEQUE COBRADO


                //SE REGISTRA LA TRANSACCION

                trans.Commit();
                ora.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                trans.Rollback();
                ora.Close();
            }
        }
    }
}
