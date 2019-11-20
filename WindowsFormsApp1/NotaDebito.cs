using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;

namespace WindowsFormsApp1
{
    public partial class NotaDebito : Form
    {
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public NotaDebito()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
            InitializeComponent();
        }

        bool ComprobarCuenta(String ctaa)
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("validar_cuenta", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cuent", OracleType.Number).Value = Convert.ToInt32(ctaa);
                    comando.Parameters.Add("resultado", OracleType.Number);
                    comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    var codigoRol = Convert.ToString(comando.Parameters["resultado"].Value);
                    return true;
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Cuenta inexistente");
                    transaction.Rollback();
                    return false;
                }
            }
        }

        private void NumeroCuenta_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCuenta.Text = NumeroCuenta.Text.Remove(NumeroCuenta.Text.Length - 1);
            }
        }

        private void Monto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Monto.Text, @"^[\d]*([.,][\d]*)?$"))
            {

            }
            else
            {
                MessageBox.Show("Ingrese solo numeros");
                Monto.Text = Monto.Text.Remove(Monto.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }
        public Boolean validarNoCuenta(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo numero de cuenta debe ser llenado");
                return false;
            }
            return true;
        }
        public Boolean validarMonto(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo monto debe ser llenado");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //crear nota
            if (!(validarNoCuenta(NumeroCuenta) && validarMonto(Monto) && ComprobarCuenta(NumeroCuenta.Text)))
            {
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("notadebito", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                OracleConnection ora = new OracleConnection(conexion);
                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("fech", OracleType.Timestamp).Value = DateTime.Now;
                    comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDecimal(Monto.Text);
                    comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                    comando.Parameters.Add("agencia", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                    comando.Parameters.Add("equipo", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se creo nota de debito correctamente");
                    NumeroCuenta.Text = "";
                    Monto.Text = "";

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Algo fallo");
                }

            }

        }
   
        private void consultar_Click(object sender, EventArgs e)
        {
            //consultar nota
            if (!(validarNoCuenta(textBox2) && ComprobarCuenta(textBox2.Text)))
            {
                return;
            }


        }

        private void NotaDebito_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }
    }
}
