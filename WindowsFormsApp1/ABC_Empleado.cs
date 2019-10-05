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
        public ABC_Empleado()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db +"; PASSWORD="+Properties.Settings.Default.contrasenia_db +"; USER ID="+Properties.Settings.Default.usuario_db+";";
            InitializeComponent();
            
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
            try
             {
                OracleConnection ora = new OracleConnection(conexion);
                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_select", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                ora.Close();
                ora.Dispose();

            }
            catch(Exception ex)
            {
                MessageBox.Show("algo salio mal");
            }
        }
        public void cargar_roles()
        {
            try
            {
                OracleConnection ora = new OracleConnection(conexion);
                ora.Open();
                OracleCommand comando = new OracleCommand("rol_select", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla1 = new DataTable();
                adaptador.Fill(tabla1);
                comboBox1.DataSource = tabla1;
                comboBox1.DisplayMember = "NOMBRE";
                comboBox1.ValueMember = "ID_ROL";
                ora.Close();
                ora.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("algo salio mal");
            }
        }
        public void cargar_agencia()
        {
            try
            {
                OracleConnection ora = new OracleConnection(conexion);
                ora.Open();
                OracleCommand comando = new OracleCommand("agencia_select", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                comboBox2.DataSource = tabla;
                comboBox2.DisplayMember = "DIRECCION";
                comboBox2.ValueMember = "ID_AGENCIA";
                comando.ExecuteNonQuery();
                ora.Close();
                ora.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("algo salio mal");
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
            if (!ComprobarEmpleado())
            {
                return;
            }

            OracleConnection ora = new OracleConnection(conexion);
            try
            {

                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_delete", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id", OracleType.Number).Value =Convert.ToInt32( codigoEmpleado.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado eliminado correctamente");

            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
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
            try
            {

                OracleConnection ora = new OracleConnection(conexion);

                ora.Open();
                OracleCommand comando = new OracleCommand("validar_empleado", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
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
                MessageBox.Show("Empleado inexistente");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!ValidarTodosCampos())
            {
                return;
            }

            if(!ComprobarEmpleado())
            {
                return;
            }

            OracleConnection ora = new OracleConnection(conexion);
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_actualizar", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(codigoEmpleado.Text);
                comando.Parameters.Add("namee", OracleType.VarChar).Value = nombre.Text;
                comando.Parameters.Add("dir", OracleType.VarChar).Value = direccion.Text;
                comando.Parameters.Add("tel", OracleType.Number).Value = Convert.ToInt32(telefono.Text);
                comando.Parameters.Add("email", OracleType.VarChar).Value = correo.Text;
                comando.Parameters.Add("ro", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comando.Parameters.Add("agen", OracleType.Number).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString()) ;
                comando.Parameters.Add("dp", OracleType.VarChar).Value = dpi.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = contrasena.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado modificado correctamente");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
            cargar_datos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidarTodosCampos())
            {
                return;
            }
            OracleConnection ora = new OracleConnection(conexion);
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_crear", ora);
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
                MessageBox.Show("Empleado creado correctamente");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
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
