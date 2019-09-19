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
    public partial class Declarar_Anomalia_Cheque : Form
    {
        public Declarar_Anomalia_Cheque()
        {
            InitializeComponent();
        }

        private void Declarar_Anomalia_Cheque_Load(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");
            ora.Open();
            OracleCommand comando = new OracleCommand("estadocheque_select", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            comboBox1.DataSource = tabla;
            comboBox1.DisplayMember = "NOMBRE";
            comboBox1.ValueMember = "CODIGO";
            ora.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("reporte_cheque", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("estado", OracleType.Number).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comando.Parameters.Add("cod", OracleType.Number).Value = Convert.ToInt32(textBox2.Text);
                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Se reporto incidencia");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
                ora.Close();
            }
        }
    }
}
