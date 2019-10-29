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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

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
            }
            catch (Exception ex)
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
            if (txt_monto.Text == "" || txt_nocheque.Text == "" || txt_nocuenta.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Debe llenar todos los campos");
                return;
            }

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
                //dr.Read();
                if (dr.Read())
                {
                    Int32 estado_chequera = Convert.ToInt32(dr["estado_cheque"]);
                    String mensaje = "";
                    if (estado_chequera == 5)
                    {
                        mensaje = "rechazado";
                    }
                    else if (estado_chequera == 4)
                    {
                        mensaje = "cobrado";
                    }
                    else if (estado_chequera == 3)
                    {
                        mensaje = "robado";
                    }
                    else if (estado_chequera == 2)
                    {
                        mensaje = "extraviado";
                    }
                    System.Windows.Forms.MessageBox.Show("Error el cheque aparece: " + mensaje);
                    return;
                }

                //VERIFICAR EL CHEQUE
                comando.Parameters.Clear();
                bool verif_cheq = false;
                Int32 chequera = 0;
                Int32 cod_cheque = Convert.ToInt32(txt_nocheque.Text);
                comando.CommandText = "SELECT * FROM chequera WHERE cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                dr = comando.ExecuteReader();
                //dr.Read();
                while (!verif_cheq && dr.Read())
                {                    
                    //CHEQUE PERTENEZCA A CHEQUERA
                    if (cod_cheque >= Convert.ToInt32(dr["numero_inicio"])  && cod_cheque <= Convert.ToInt32(dr["numero_final"]))
                    {
                        verif_cheq = true;
                        chequera = Convert.ToInt32(dr["codigo_chequera"]);
                    }
                    //dr.NextResult();
                }

                if (!verif_cheq)
                {
                    //RECHAZAR CHEQUE
                    System.Windows.Forms.MessageBox.Show("El cheque no pertenece a ninguna chequera o a esa cuenta");
                    return;
                }

                //VERIFICA EL SALDO
                comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                dr = comando.ExecuteReader();
                dr.Read();
                Int32 saldo = Convert.ToInt32(dr["saldo_disponible"]);
                double monto = Convert.ToDouble(txt_monto.Text);
                DateTime fecha = DateTime.Now;
                //.ToString("MM/dd/yyyy hh:mm:ss tt")
                if (saldo < monto)
                {
                    System.Windows.Forms.MessageBox.Show("Saldo Insuficiente");
                    //RECHAZAR CHEQUE
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                        "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                    comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = cod_cheque;
                    comando.Parameters.Add("fecha",OracleType.DateTime).Value = fecha;
                    comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                    comando.Parameters.Add("chequera",OracleType.Number).Value = chequera;
                    comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 5;
                    comando.ExecuteNonQuery();

                    //GRABAR TRANSACCION
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO TRANSACCION (NO_RECHAZO, RAZON_RECHAZO, FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                        "VALUES(:rechazo, :razon,:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'0',:equipo,:cheque)";
                    comando.Parameters.Add("rechazo", OracleType.Number).Value = 1;
                    comando.Parameters.Add("razon",OracleType.VarChar).Value = "NO TIENE FONDOS";
                    comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                    comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                    comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                    comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                    comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                    comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                    comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                    comando.ExecuteNonQuery();
                    return;
                }

                //SE DEBITA DE LA CUENTA
                comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible - :monto WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.ExecuteNonQuery();

                //CHEQUE COBRADO
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                        "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = cod_cheque;
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("chequera", OracleType.Number).Value = chequera;
                comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 4;
                comando.ExecuteNonQuery();

                //SE REGISTRA LA TRANSACCION
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'0',:equipo,:cheque)";
                comando.Parameters.Add("fecha",OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                comando.Parameters.Add("cheque",OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("se ha realizado la operacion exitosamente");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                trans.Commit();
                ora.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_monto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
