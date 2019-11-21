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
    public partial class TRANSFERENCIA_FONDOS : Form
    {
        OracleConnection ora;
        OracleDataAdapter adaptador;
        OracleCommand comando;

        public TRANSFERENCIA_FONDOS()
        {
            InitializeComponent();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void TRANSFERENCIA_FONDOS_Load(object sender, EventArgs e)
        {
            ora = new OracleConnection(
               "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
               "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
               "USER ID=" + Properties.Settings.Default.usuario_db + ";"
               );
            this.btn_transf.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT firma,foto,dpi FROM CLIENTE WHERE codigo_cliente = (SELECT cliente FROM CLIENTE_CUENTA WHERE cuenta = :cuenta)";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_a.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                ABC_CLIENTE b = new ABC_CLIENTE();
                byte[] firma = (byte[])(dr["firma"]);
                byte[] foto = (byte[])(dr["foto"]);
                String ruta = b.convert_blob_to_image(firma, "firmax");
                pic_firma.Image = Image.FromFile(ruta);
                ruta = b.convert_blob_to_image(foto, "fotox");
                pic_foto.Image = Image.FromFile(ruta);
                label7.Text = dr["dpi"].ToString();
                this.btn_transf.Enabled = true;
            }
            catch (Exception ex)
            {
                this.btn_transf.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Debe ingresar un numero de cuenta valida");
            }
            finally
            {
                ora.Close();
            }
        }

        private void btn_transf_Click(object sender, EventArgs e)
        {
            if (txt_monto.Text == "" || txt_cuenta_a.Text == "" || txt_cuenta_b.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            double distance = 0;
            if (!double.TryParse(txt_monto.Text, out distance))
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar un numero valido para el monto");
                return;
            }

            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            OracleTransaction trans = ora.BeginTransaction();
            comando.Transaction = trans;
            try
            {
                //verificar que la cuenta A tenga fondos
                comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_a.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                double saldo = Convert.ToDouble(dr["saldo_disponible"]);
                double monto = Convert.ToDouble(txt_monto.Text);
                if (saldo < monto)
                {
                    System.Windows.Forms.MessageBox.Show("Saldo Insuficiente");
                    return;
                }
                //verficamos la existencia de la cuenta b
                comando.Parameters.Clear();
                comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_b.Text);
                dr = comando.ExecuteReader();
                if (!dr.Read()) {
                    System.Windows.Forms.MessageBox.Show("No existe la cuenta "+txt_cuenta_b.Text);
                    return;
                }
                //transferir a la cuenta b
                comando.Parameters.Clear();
                comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible - :monto WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_a.Text);
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.ExecuteNonQuery();

                comando.Parameters.Clear();
                comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible + :monto WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_b.Text);
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.ExecuteNonQuery();
                //registar transaccion
                DateTime fecha = DateTime.Now;
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO) " +
                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'0',:equipo)";
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_a.Text);
                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                comando.Parameters.Add("agencia", OracleType.Number).Value = Properties.Settings.Default.agencia;
                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                comando.ExecuteNonQuery();

                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO) " +
                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'1',:equipo)";
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_cuenta_b.Text);
                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                comando.Parameters.Add("agencia", OracleType.Number).Value = Properties.Settings.Default.agencia;
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
    }
}
