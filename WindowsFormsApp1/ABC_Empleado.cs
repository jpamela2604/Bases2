using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ABC_Empleado : Form
    {
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public ABC_Empleado()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db +"; PASSWORD="+Properties.Settings.Default.contrasenia_db +"; USER ID="+Properties.Settings.Default.usuario_db+";";
            InitializeComponent();
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                codigoEmpleado.Text = row.Cells[0].Value.ToString();
                nombre.Text = row.Cells[1].Value.ToString();
                direccion.Text = row.Cells[2].Value.ToString();
                telefono.Text = row.Cells[3].Value.ToString();
                correo.Text = row.Cells[4].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(row.Cells[5].Value.ToString());
                comboBox2.SelectedIndex = comboBox2.FindStringExact(row.Cells[6].Value.ToString());
                dpi.Text = row.Cells[7].Value.ToString();
                contrasena.Text = row.Cells[8].Value.ToString();
            }
        }
        public void cargar_datos()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("empleado_select", connection);
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
                    dataGridView1.DataSource = tabla;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("algo salio mal");
                }
            }
        }
        public void cargar_roles()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("rol_select", connection);
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
                    DataTable tabla1 = new DataTable();
                    adaptador.Fill(tabla1);
                    comboBox1.DataSource = tabla1;
                    comboBox1.DisplayMember = "NOMBRE";
                    comboBox1.ValueMember = "ID_ROL";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("algo salio mal");
                    transaction.Rollback();
                }
            }
        }
        public void cargar_agencia()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("agencia_select", connection);
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
                    comboBox2.DataSource = tabla;
                    comboBox2.DisplayMember = "DIRECCION";
                    comboBox2.ValueMember = "ID_AGENCIA";
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("algo salio mal");
                    transaction.Rollback();
                }
            }
        }
        private void ABC_Empleado_Load(object sender, EventArgs e)
        {
            cargar_datos();
            cargar_roles();
            cargar_agencia();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            //eliminar empleado
            if (!ComprobarEmpleado())
            {
                MessageBox.Show("empleado inexistente");
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("empleado_delete", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                OracleConnection ora = new OracleConnection(conexion);
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("id", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Empleado eliminado correctamente");

                }
                catch (Exception)
                {
                    MessageBox.Show("Algo fallo");
                    transaction.Rollback();
                }
            }
            cargar_datos();
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

        bool ValidarTelefono()
        {
            if(telefono.Text.Length!=8)
            {
                MessageBox.Show("El campo telefono debe tener 8 digitos");
                return false;
            }else if (dpi.Text.Length != 13)
            {
                MessageBox.Show("El campo dpi debe tener 13 digitos");
                return false;
            }
            return true;
        }
        bool ValidarTodosCampos()
        {
            if(CheckTextBox(codigoEmpleado)&& CheckTextBox(nombre)&& CheckTextBox(direccion)
                && CheckTextBox(telefono)&& CheckTextBox(correo)&& CheckTextBox(dpi)&& CheckTextBox(contrasena)
                && validarCorreo()&& ValidarTelefono())
            {
                return true;
            }
            return false;
        }
        bool ComprobarEmpleado()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("validar_empleado", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {
                    
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
                    comando.Parameters.Add("resultado", OracleType.Number);
                    comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    //comando.Connection.Close();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    var codigoRol = Convert.ToString(comando.Parameters["resultado"].Value);
                    return true;
                }
                catch (Exception EX)
                {
                    transaction.Rollback();
                   
                    return false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //modificar
            if (!ComprobarEmpleado())
            {
                MessageBox.Show("empleado inexistente");
                return;
            }
            if (!ValidarTodosCampos())
            {
                return;
            }

            
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("empleado_actualizar", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
                    comando.Parameters.Add("namee", OracleType.VarChar).Value = nombre.Text;
                    comando.Parameters.Add("dir", OracleType.VarChar).Value = direccion.Text;
                    comando.Parameters.Add("tel", OracleType.Number).Value = Convert.ToInt32(telefono.Text);
                    comando.Parameters.Add("email", OracleType.VarChar).Value = correo.Text;
                    comando.Parameters.Add("ro", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    comando.Parameters.Add("agen", OracleType.Number).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    comando.Parameters.Add("dp", OracleType.VarChar).Value = dpi.Text;
                    comando.Parameters.Add("pass", OracleType.VarChar).Value = contrasena.Text;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Empleado modificado correctamente");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Algo fallo");
                }
            }
            cargar_datos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //crear
            if (!ValidarTodosCampos())
            {
                return;
            }
            if(ComprobarEmpleado())
            {
                MessageBox.Show("Ya existe empleado con ese codigo de empleado");
                return;
            }
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("empleado_crear", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                OracleConnection ora = new OracleConnection(conexion);
                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
                    comando.Parameters.Add("namee", OracleType.VarChar).Value = nombre.Text;
                    comando.Parameters.Add("dir", OracleType.VarChar).Value = direccion.Text;
                    comando.Parameters.Add("tel", OracleType.Number).Value = Convert.ToInt32(telefono.Text);
                    comando.Parameters.Add("email", OracleType.VarChar).Value = correo.Text;
                    comando.Parameters.Add("ro", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    comando.Parameters.Add("agen", OracleType.Number).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    comando.Parameters.Add("dp", OracleType.VarChar).Value = dpi.Text;
                    comando.Parameters.Add("pass", OracleType.VarChar).Value = contrasena.Text;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Empleado creado correctamente");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Algo fallo");
                }

            }
            cargar_datos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }

        private void codigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(codigoEmpleado.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                codigoEmpleado.Text = codigoEmpleado.Text.Remove(codigoEmpleado.Text.Length - 1);
            }
        }
        private bool validarCorreo()
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(correo.Text.Trim());
            if (!isValid)
            {
                MessageBox.Show("Correo invalido");
                return false;
            }
            return true;
        }
        private void telefono_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(telefono.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                telefono.Text = telefono.Text.Remove(telefono.Text.Length - 1);
            }
        }

        private void dpi_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(dpi.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                dpi.Text = dpi.Text.Remove(dpi.Text.Length - 1);
            }
        }
    }
}
