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
        OracleConnection ora = new OracleConnection("DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";");
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
        bool CheckTextBox(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo "+ tb.Name + " debe ser llenado");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckTextBox(Usuario) && CheckTextBox(Contrasena))
            {
                try
                {

                    

                    ora.Open();
                    OracleCommand comando = new OracleCommand("login", ora);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("usuario", OracleType.Number).Value = Convert.ToInt32(Usuario.Text);
                    comando.Parameters.Add("password", OracleType.VarChar).Value = Contrasena.Text;
                    comando.Parameters.Add("resultado", OracleType.Number);
                    comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    var codigoRol = Convert.ToInt32(comando.Parameters["resultado"].Value);
                    Properties.Settings.Default.rol = codigoRol;
                    MessageBox.Show("Bienvenido");
                }
                catch (Exception EX)
                {
                    Usuario.Text = "";
                    Contrasena.Text = "";
                    MessageBox.Show("usuario y/o contraseña invalidos");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
