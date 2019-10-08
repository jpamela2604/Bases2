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
    public partial class SolicitudChequera : Form
    {
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public SolicitudChequera()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
            InitializeComponent();            
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
        bool positivo()
        {
            if((int)numericUpDown1.Value<=0)
            {
                MessageBox.Show("El campo cantidad debe ser mayor a cero");
                return false;
            }
            return true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(CheckTextBox(NumeroCuenta)&& positivo()&& ComprobarCuenta()))
            {
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("solicitar_chequera", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;

                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("numero_cuenta", OracleType.VarChar).Value = Convert.ToInt32(NumeroCuenta.Text);
                    comando.Parameters.Add("cantidad", OracleType.VarChar).Value = (int)numericUpDown1.Value;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se envió la solicitud");
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo fallo");
                    transaction.Rollback();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCuenta.Text = NumeroCuenta.Text.Remove(NumeroCuenta.Text.Length - 1);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
