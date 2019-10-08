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
    public partial class DepositoMonetario : Form
    {
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public int tipoPago;
        /*
         * 0. ninguno
         * 1. monetaria
         * 2. cheque
         */
        public DepositoMonetario()
        {
            tipoPago = 0;
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
            InitializeComponent();
            Visualizacion(false);
            tbTipoCheque.SelectedItem = null;
            tbTipoCheque.Items.Add("Seleccione");
            tbTipoCheque.Items.Add("Local");
            tbTipoCheque.Items.Add("Externo");
            tbTipoCheque.SelectedIndex = 0;
            //ocultar cosas
            checkEfectivo.Visible = false;
            checkCheque.Visible = false;
            checkEfectivo.CheckState = CheckState.Checked;
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCuenta.Text = NumeroCuenta.Text.Remove(NumeroCuenta.Text.Length - 1);
            }
        }

        private void tbNoCheque_TextChanged(object sender, EventArgs e)
        {
            
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCheque.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCheque.Text = NumeroCheque.Text.Remove(NumeroCheque.Text.Length - 1);
            }
        }

        private void checkEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            tipoPago = 0;
            if (checkEfectivo.CheckState == CheckState.Checked)
            {
                checkCheque.CheckState = CheckState.Unchecked;
                Visualizacion(false);
                tipoPago = 1;
            }
        }

        private void checkCheque_CheckedChanged(object sender, EventArgs e)
        {
            tipoPago = 0;
            if (checkCheque.CheckState == CheckState.Checked)
            {
                checkEfectivo.CheckState = CheckState.Unchecked;
                Visualizacion(true);
                tipoPago = 2;
            }
        }
        public bool verificarCheque()
        {
            if (tipoPago==2)
            {
                if(!CheckTextBox(NumeroCheque))
                {
                    return false;
                }
                if(tbTipoCheque.SelectedItem == null|| tbTipoCheque.SelectedIndex==0)
                {
                    MessageBox.Show("Seleccione el tipo de cheque");
                    return false;

                }
            }
            return true;
        }
        public void Visualizacion(Boolean valor)
        {
            label4.Visible = valor;
            label5.Visible = valor;
            tbTipoCheque.Visible = valor;
            NumeroCheque.Visible = valor;
            NumeroCheque.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(CheckTextBox(NumeroCuenta)&& CheckTextBox(Monto)&& selectTipo()&& verificarCheque()
                && ComprobarCuenta()))
            {
                return;
            }

            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("deposito", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                OracleConnection ora = new OracleConnection(conexion);
                //try
                //{
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("fech", OracleType.Timestamp).Value =DateTime.Now;
                    comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDecimal(Monto.Text);
                    comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                    comando.Parameters.Add("agencia", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                    comando.Parameters.Add("equipo", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se hizo el deposito correctamente");
                    NumeroCuenta.Text = "";
                    Monto.Text = "";

                /*}
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Algo fallo");
                }*/

            }

        }
        bool selectTipo()
        {
            if(checkEfectivo.CheckState == CheckState.Checked|| checkCheque.CheckState == CheckState.Checked)
            {
                return true;
            }
            MessageBox.Show("Seleccione si el deposito es en efectivo o cheque");
            return false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }
    }
}
