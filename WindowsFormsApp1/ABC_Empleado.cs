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
    public partial class ABC_Empleado : Form
    {
        public ABC_Empleado()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void cargar_datos()
        {
            try
             {
                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
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
                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
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
                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
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
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
            try
            {

                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_delete", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id", OracleType.Number).Value =Convert.ToInt32( textBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_actualizar", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
                comando.Parameters.Add("namee", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("dir", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("tel", OracleType.Number).Value = Convert.ToInt32(textBox4.Text);
                comando.Parameters.Add("email", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("ro", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comando.Parameters.Add("agen", OracleType.Number).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString()) ;
                comando.Parameters.Add("dp", OracleType.VarChar).Value = textBox6.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = textBox7.Text;
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
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("empleado_crear", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
                comando.Parameters.Add("namee", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("dir", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("tel", OracleType.Number).Value = Convert.ToInt32(textBox4.Text);
                comando.Parameters.Add("email", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("ro", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comando.Parameters.Add("agen", OracleType.Number).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                comando.Parameters.Add("dp", OracleType.VarChar).Value = textBox6.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = textBox7.Text;
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
    }
}
