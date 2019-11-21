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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new ABC_CLIENTE();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new ABC_CUENTA();
            f2.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Menu_FormClosing(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f2 = new PAGO_CHEQUE();
            f2.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f2 = new TRANSFERENCIA_FONDOS();
            f2.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            //this.Hide();
            m.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AUDITORIA a = new AUDITORIA();
            //this.Hide();
            a.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Consultas c = new Consultas();
            //this.Hide();
            c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Deposito DE = new Deposito();
            DE.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ConsultaSaldos S = new ConsultaSaldos();
            S.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pgobnk_Click(object sender, EventArgs e)
        {
            PAGO_OTRO_BANCO S = new PAGO_OTRO_BANCO();
            S.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NotaCredito S = new NotaCredito();
            S.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NotaDebito S = new NotaDebito();
            S.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ConsultaSaldos S = new ConsultaSaldos();
            S.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Declarar_Anomalia_Cheque S = new Declarar_Anomalia_Cheque();
            S.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SolicitudChequera S = new SolicitudChequera();
            S.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ABC_BANCO S = new ABC_BANCO();
            S.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ABC_Empleado S = new ABC_Empleado();
            S.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ABC_Agencia S = new ABC_Agencia();
            S.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ABC_Rol S = new ABC_Rol();
            S.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ABC_Equipo S = new ABC_Equipo();
            S.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Declarar_Anomalia_Cheque S = new Declarar_Anomalia_Cheque();
            S.Show();
        }
    }
}
