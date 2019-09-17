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
    public partial class MenuCuentasNuevas : Form
    {
        public MenuCuentasNuevas()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 principal = new Form1();
            principal.Show();
        }

        private void btnDatosCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABC_Cliente cliente = new ABC_Cliente();
            cliente.Show();
        }

        private void btnAperturarCuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cuenta_Nueva cn = new Cuenta_Nueva();
            cn.Show();
        }

        private void btnBloquearCuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            CanBloq_Cuenta cn = new CanBloq_Cuenta();
            cn.Show();
        }
    }
}
