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
    public partial class ABC_Equipo : Form
    {
        public ABC_Equipo()
        {
            InitializeComponent();

            Conexion.abrirConexion();

            OracleCommand comando = new OracleCommand("agencia_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            foreach (DataRow row in tabla.Rows)
            {
                comboBox1.Items.Add(row[0] + "-" + row[1].ToString());
                comboBox2.Items.Add(row[0] + "-" + row[1].ToString());
            }

            OracleCommand comando2 = new OracleCommand("equipo_select", Conexion.ora);
            comando2.CommandType = System.Data.CommandType.StoredProcedure;
            comando2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = comando2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            foreach (DataRow row in tabla2.Rows)
            {
                comboBox3.Items.Add(row[0] + "-" + row[1].ToString());
                comboBox4.Items.Add(row[0] + "-" + row[1].ToString());
            }

            Conexion.cerrarConexion();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuMantenimientoDBA m = new MenuMantenimientoDBA();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("equipo_insert", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("descripcion", OracleType.VarChar).Value = richTextBox1.Text;
                var id = comboBox1.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("id_agencia", OracleType.VarChar).Value = id[0];
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();
            OracleCommand comando = new OracleCommand("equipo_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.cerrarConexion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("equipo_update", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var id = comboBox3.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("psku", OracleType.VarChar).Value = id[0];
                comando.Parameters.Add("pdescripcion", OracleType.VarChar).Value = richTextBox2.Text;
                var id2 = comboBox2.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("id_agencia", OracleType.VarChar).Value = id2[0];

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }

            Conexion.cerrarConexion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();
            try
            {
                OracleCommand comando = new OracleCommand("equipo_delete", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var id = comboBox4.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("psku", OracleType.VarChar).Value = id[0];
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }
            Conexion.cerrarConexion();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
