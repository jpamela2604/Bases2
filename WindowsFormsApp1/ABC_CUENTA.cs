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
    public partial class ABC_CUENTA : Form
    {
        public ABC_CUENTA()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        int c = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox txtRun = new TextBox();
            txtRun.Name = "txtDynamic" + c++;
            //txtRun.Location = new System.Drawing.Point(20, 18 + (20 * c));
            txtRun.Size = new System.Drawing.Size(200, 25);
            flowLayoutPanel1.Controls.Add(txtRun);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c--;
            flowLayoutPanel1.Controls.RemoveByKey("txtDynamic" + c);
        }
    }
}
