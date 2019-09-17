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
    public partial class ABC_Cliente : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=admin; USER ID=system;");
        public ABC_Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("cliente_select", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            ora.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("cliente_insert", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pnombre", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("pdireccion", OracleType.VarChar).Value = textBox1.Text;
                comando.Parameters.Add("pnit", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("ptelefono", OracleType.VarChar).Value = textBox4.Text;
                comando.Parameters.Add("pcorreo", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("ptipo_cliente", OracleType.VarChar).Value = textBox6.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("cliente_update", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_cliente", OracleType.VarChar).Value = textBox7.Text;
                comando.Parameters.Add("pnombre", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("pdireccion", OracleType.VarChar).Value = textBox1.Text;
                comando.Parameters.Add("pnit", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("ptelefono", OracleType.VarChar).Value = textBox4.Text;
                comando.Parameters.Add("pcorreo", OracleType.VarChar).Value = textBox5.Text;
                comando.Parameters.Add("ptipo_cliente", OracleType.VarChar).Value = textBox6.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("cliente_delete", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pid_cliente", OracleType.VarChar).Value = textBox8.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            ora.Close();
        }
    }
}
