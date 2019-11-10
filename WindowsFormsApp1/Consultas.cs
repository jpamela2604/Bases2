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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
            Conexion.abrirConexion();

            OracleCommand comando = new OracleCommand("cuenta_select_dani", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            foreach (DataRow row in tabla.Rows)
            {
                comboBox1.Items.Add(row[0]);
            }
            Conexion.cerrarConexion();

            Conexion.abrirConexion();

            OracleCommand comando2 = new OracleCommand("agencia_select", Conexion.ora);
            comando2.CommandType = System.Data.CommandType.StoredProcedure;
            comando2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = comando2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            foreach (DataRow row in tabla2.Rows)
            {
                comboBox2.Items.Add(row[0] + "-" +row[1]);
            }
            Conexion.cerrarConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("consulta_saldos_por_cuenta", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                var id = comboBox1.SelectedItem.ToString();
                comando.Parameters.Add("cuenta_id", OracleType.VarChar).Value = id;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                Conexion.cerrarConexion();

                foreach (DataRow row in tabla.Rows)
                {
                    Series serie = chart1.Series.Add("Disponible");
                    serie.Label = "Disponible";
                    serie.Points.Add(Double.Parse(row[0].ToString()));

                    Series seriex = chart1.Series.Add("Reserva");
                    seriex.Label = "Reserva";
                    seriex.Points.Add(Double.Parse(row[1].ToString()));

                    Series seriexx = chart1.Series.Add("Real");
                    seriexx.Label = "Real";
                    seriexx.Points.Add(Double.Parse(row[2].ToString()));
                }
                Conexion.cerrarConexion();
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                chart1.Titles.Add("Consulta de Saldos");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("clientes_no_agencia", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                var id = comboBox2.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("agencia_num", OracleType.VarChar).Value = id[0];
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                Conexion.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("saldos_por_agencia", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                var id = comboBox2.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("id_agencia_", OracleType.VarChar).Value = id[0];
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                Conexion.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();

            try
            {
                Conexion.abrirConexion();
                OracleCommand comandox = new OracleCommand("saldos_por_agencia_unico_dato", Conexion.ora);
                comandox.CommandType = System.Data.CommandType.StoredProcedure;
                comandox.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adaptadorx = new OracleDataAdapter();
                adaptadorx.SelectCommand = comandox;
                DataTable tablax = new DataTable();
                adaptadorx.Fill(tablax);
                foreach (DataRow row in tablax.Rows)
                {
                    chart1.Series["Series1"].Points.AddXY(row[1],row[0]);
                }
                Conexion.cerrarConexion();
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie; ;
                chart1.Titles.Add("Saldos por Agencia");
            }
            catch (Exception)
            {
                
            }
            
        }

        private void btn_mas_depositos_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("MAS_DEPOSITOS", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                Conexion.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }

        private void btn_max_monto_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("MONTO_MAXIMO", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                Conexion.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }
    }
}
