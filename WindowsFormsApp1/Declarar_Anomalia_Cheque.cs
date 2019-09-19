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
    public partial class Declarar_Anomalia_Cheque : Form
    {
        public Declarar_Anomalia_Cheque()
        {
            InitializeComponent();
        }

        private void Declarar_Anomalia_Cheque_Load(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
            ora.Open();
            OracleCommand comando = new OracleCommand("estadocheque_select", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            comboBox1.DataSource = tabla;
            comboBox1.DisplayMember = "NOMBRE";
            comboBox1.ValueMember = "CODIGO";
            ora.Close();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(!(CheckTextBox(NumeroCuenta)&&CheckTextBox(NumeroCheque)&& ComprobarCuenta()&& ComprobarCheque()))
            {
                return;
            }
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("reporte_cheque", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("estado", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(NumeroCheque.Text);
                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Se reporto incidencia");
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
        bool ComprobarCuenta()
        {
            try
            {

                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

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
        bool ComprobarCheque()
        {
            try
            {

                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

                ora.Open();
                OracleCommand comando = new OracleCommand("validar_cheque", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(NumeroCheque.Text);
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
                MessageBox.Show("Cheque inexistente");
                return false;
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

        private void NumeroCheque_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCheque.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCheque.Text = NumeroCheque.Text.Remove(NumeroCheque.Text.Length - 1);
            }
        }
    }
}
