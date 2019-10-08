using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuMantenimientoDBA : Form
    {
        public MenuMantenimientoDBA()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 principal = new Form1();
            principal.Show();
        }

        private void btnCRUDBancos_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_BANCO abc_banco = new ABC_BANCO();
            abc_banco.Show();
        }

        private void btnCRUDUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_CLIENTE abc_cliente = new ABC_CLIENTE();
            abc_cliente.Show();
        }

        private void btnCRUDAgencias_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_Agencia abc_agencia = new ABC_Agencia();
            abc_agencia.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_Equipo abc_cliente = new ABC_Equipo();
            abc_cliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_Rol abc_cliente = new ABC_Rol();
            abc_cliente.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Funciones abc_cliente = new Funciones();
            abc_cliente.Show();
        }

        private void MenuMantenimientoDBA_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Asignacion_Rol abc_cliente = new Asignacion_Rol();
            abc_cliente.Show();
        }
    }
}
