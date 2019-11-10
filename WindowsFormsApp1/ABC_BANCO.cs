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
    public partial class ABC_BANCO : Form
    {
        public ABC_BANCO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Conexion.abrirConexion();
            OracleCommand comando = new OracleCommand("banco_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.cerrarConexion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuMantenimientoDBA m = new MenuMantenimientoDBA();
            m.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conexion.abrirConexion();
                OracleCommand comando = new OracleCommand("banco_insert", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("nombre", OracleType.VarChar).Value = textBox1.Text;
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
                OracleCommand comando = new OracleCommand("banco_update", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_banco", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("pnombre", OracleType.VarChar).Value = textBox4.Text;
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
                OracleCommand comando = new OracleCommand("banco_delete", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_banco", OracleType.VarChar).Value = textBox6.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            Conexion.cerrarConexion();
        }
    }
}
