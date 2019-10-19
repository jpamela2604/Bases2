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
    public partial class ABC_Rol : Form
    {
        public ABC_Rol()
        {
            InitializeComponent();
            Conexion.abrirConexion();

            OracleCommand comando = new OracleCommand("rol_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            foreach (DataRow row in tabla.Rows)
            {
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
                OracleCommand comando = new OracleCommand("rol_insert", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("nombre", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("descripcion", OracleType.VarChar).Value = richTextBox1.Text;
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
                OracleCommand comando = new OracleCommand("rol_delete", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var id = comboBox4.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("pid_rol", OracleType.VarChar).Value = id[0];
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
            OracleCommand comando = new OracleCommand("rol_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.cerrarConexion();
        }

    }
}
