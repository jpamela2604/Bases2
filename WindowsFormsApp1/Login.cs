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
    public partial class Login : Form
    {
        Conexion c = new Conexion();
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                OracleConnection ora = new OracleConnection("DATA SOURCE = orcl; PASSWORD=pampam; USER ID=SYSTEM;");

                ora.Open();
                OracleCommand comando = new OracleCommand("login", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("usuario", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
                comando.Parameters.Add("password", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("resultado", OracleType.Number);
                comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
                /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                var codigoRol = Convert.ToString(comando.Parameters["resultado"].Value);                
            }catch(Exception EX)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("usuario y/o contraseña invalidos");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
