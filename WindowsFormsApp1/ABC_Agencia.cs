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
    public partial class ABC_Agencia : Form
    {
        //Cadena de conexion
        

        public ABC_Agencia()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Conexion.abrirConexion();
            OracleCommand comando = new OracleCommand("agencia_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.cerrarConexion();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conexion.abrirConexion();
                OracleCommand comando = new OracleCommand("agencia_insert", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("direccion", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("descripcion", OracleType.VarChar).Value = richTextBox1.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            Conexion.cerrarConexion();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conexion.abrirConexion();
                OracleCommand comando = new OracleCommand("agencia_update", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_agencia", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("pdireccion", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("pdescripcion", OracleType.VarChar).Value = richTextBox2.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            Conexion.cerrarConexion();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conexion.abrirConexion();
                OracleCommand comando = new OracleCommand("agencia_delete", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_agencia", OracleType.VarChar).Value = textBox6.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            Conexion.cerrarConexion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuMantenimientoDBA m = new MenuMantenimientoDBA();
            m.Show();

        }


    }
}
