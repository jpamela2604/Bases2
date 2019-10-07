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
    public partial class depositomonetario : Form
    {
        public depositomonetario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection(
                "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
                "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
                "USER ID=" + Properties.Settings.Default.usuario_db + ";"
                );
            OracleCommand command;
            ora.Open();
            command = new OracleCommand();
            command.Connection = ora;
            OracleTransaction transac = ora.BeginTransaction();
            command.Transaction = transac;

            //realizar el deposito en el numero de cuenta
            command.CommandText = "UPDATE CUENTA SET saldo_disponible = saldo_disponible + :deposito WHERE numero_cuenta == :cuenta";
            command.Parameters.Add("deposito", OracleType.Number).Value = Convert.ToInt32(box_deposito.Text);
            command.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(box_cuenta);
            command.ExecuteNonQuery();

            //grabar la transaccion

            System.Windows.Forms.MessageBox.Show("Se ha realizado el deposito exitosamente");           
        }
    }
}
