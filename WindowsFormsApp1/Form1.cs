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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuMantenimientoDBA menu = new MenuMantenimientoDBA();
            menu.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Permisos.esDBA(Properties.Settings.Default.id_empledo.ToString()) == false)
            {
                btnMantenimientoDBA.Visible = false;
            }
        }

        private void btnNuevasCuentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCuentasNuevas menu = new MenuCuentasNuevas();
            menu.Show();
        }
    }
}
