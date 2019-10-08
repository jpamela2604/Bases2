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
    public partial class ConsultaSaldos : Form
    {

        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public ConsultaSaldos()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
            InitializeComponent();
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(CheckTextBox(NumeroCuenta)&& ComprobarCuenta()))
            {
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("disponible", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                    comando.Parameters.Add("resultado", OracleType.Number);
                    comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                    comando.Transaction = transaction;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    comando.Connection.Close();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    double disp = Convert.ToDouble(comando.Parameters["resultado"].Value);
                    label6.Text= "Q. "+disp;

                connection.Open();
                comando = new OracleCommand("reserva", connection);
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                comando.Parameters.Add("resultado", OracleType.Number);
                comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                comando.Transaction = transaction;
                comando.ExecuteNonQuery();
                transaction.Commit();
                comando.Connection.Close();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    double rese = Convert.ToDouble(comando.Parameters["resultado"].Value);
                label7.Text = "Q. " + rese;
                    double real = disp + rese;
                    label8.Text = "Q. " + real;

                }
                catch (Exception EX)
                {
                    transaction.Rollback();
                    MessageBox.Show("algo salio mal");
                }
            }
        }
        bool ComprobarCuenta()
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
                    comando.Parameters.Add("cuent", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
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

        bool CheckTextBox(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo " + tb.Name + " debe ser llenado");
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }

        private void NumeroCuenta_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCuenta.Text = NumeroCuenta.Text.Remove(NumeroCuenta.Text.Length - 1);
            }
        }
    }
}
