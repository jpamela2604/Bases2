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
        public SolicitudChequera()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
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
            try
            {

                OracleConnection ora = new OracleConnection(conexion);

                ora.Open();
                OracleCommand comando = new OracleCommand("validar_cuenta", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cuent", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                comando.Parameters.Add("resultado", OracleType.Number);
                comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
                /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                var codigoRol = Convert.ToString(comando.Parameters["resultado"].Value);
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show("Cuenta inexistente");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(CheckTextBox(NumeroCuenta)&& positivo()&& ComprobarCuenta()))
            {
                return;
            }
            OracleConnection ora = new OracleConnection(conexion);

            try
           {
               ora.Open();
                OracleCommand comando = new OracleCommand("solicitar_chequera", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("numero_cuenta", OracleType.VarChar).Value = Convert.ToInt32(NumeroCuenta.Text);
                comando.Parameters.Add("cantidad", OracleType.VarChar).Value = (int)numericUpDown1.Value; 
                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Se envió la solicitud");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
                ora.Close();
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
