﻿using System;
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

        }

        private void MenuCuentasNuevas_Load(object sender, EventArgs e)
        {

            if (Permisos.esCajero(Properties.Settings.Default.id_empledo.ToString()) == true)
            {
                btnAperturarCuenta.Visible = false;
                btnBloquearCuenta.Visible = false;

            }
        }
    }
}
