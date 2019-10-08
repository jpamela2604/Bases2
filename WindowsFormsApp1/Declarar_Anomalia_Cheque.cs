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
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public Declarar_Anomalia_Cheque()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            InitializeComponent();
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
        }

        private void Declarar_Anomalia_Cheque_Load(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("estadocheque_select", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adaptador = new OracleDataAdapter();
                    adaptador.SelectCommand = comando;
                    transaction.Commit();
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    comboBox1.DataSource = tabla;
                    comboBox1.DisplayMember = "NOMBRE";
                    comboBox1.ValueMember = "CODIGO";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("algo salio mal");
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
            bool RelacionarCuentaCheque()
            {
                using (OracleConnection connection = new OracleConnection(conexion))
                {
                    connection.Open();
                    OracleCommand comando = new OracleCommand("validad_cuenta_cheque", connection);
                    OracleTransaction transaction;
                    transaction = connection.BeginTransaction(lectura);
                    comando.Transaction = transaction;
                    try
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                        comando.Parameters.Add("che", OracleType.Number).Value = Convert.ToInt32(NumeroCheque.Text);
                        comando.Parameters.Add("resultado", OracleType.Number);
                        comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                        comando.ExecuteNonQuery();
                        transaction.Commit();
                        /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                        var codigoRol = Convert.ToInt32(comando.Parameters["resultado"].Value);

                        if (codigoRol == 1)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("La cuenta no esta relacionada con el cheque");
                            return false;
                        }

                    }
                    catch (Exception EX)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Algo salio mal");
                    }
                }
                return false;
            }


            private void button1_Click(object sender, EventArgs e)
        {
            if (!(CheckTextBox(NumeroCuenta)&&CheckTextBox(NumeroCheque)&& ComprobarCuenta()&& ComprobarCheque()&& RelacionarCuentaCheque()))
            {
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("reporte_cheque", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;                

                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("estado", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(NumeroCheque.Text);
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se reporto incidencia");
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
        bool ComprobarCheque()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("validar_cheque", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {
                    
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(NumeroCheque.Text);
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
                    MessageBox.Show("Cheque inexistente");
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
