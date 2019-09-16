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
    }
}
