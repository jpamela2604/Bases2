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
    public partial class SolicitudChequera : Form
    {
        public SolicitudChequera()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

            try
           {
               ora.Open();
                OracleCommand comando = new OracleCommand("solicitar_chequera", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("numero_cuenta", OracleType.VarChar).Value = Convert.ToInt32(textBox1.Text);
                comando.Parameters.Add("cantidad", OracleType.VarChar).Value = (int)numericUpDown1.Value; 
                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Se envió la solicitud");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
                ora.Close();
            }
            
            
        }
    }
}
