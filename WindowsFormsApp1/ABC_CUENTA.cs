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
    public partial class ABC_CUENTA : Form
    {
        OracleConnection ora;
        OracleDataAdapter adaptador;
        OracleCommand comando;

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
            txtRun.Name = "box_cuenta" + c++;
            txtRun.Size = new System.Drawing.Size(200, 25);
            flow_cuentas.Controls.Add(txtRun);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c--;
            flow_cuentas.Controls.RemoveByKey("box_cuenta" + c);
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            var saldo_disponible = box_saldo.Text;
            var estado_cuenta = 1;
            var tipo_cuenta = 1;
            if (flow_cuentas.Controls.Count > 1) {
                tipo_cuenta = 2;
            }

            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            OracleTransaction trans = ora.BeginTransaction();
            comando.Transaction = trans;

            try
            {
                //primero se crea la cuenta    
                comando.CommandText = "INSERT INTO CUENTA (ESTADO, SALDO_DISPONIBLE, ESTADO_CUENTA, EN_RESERVA, TIPO_CUENTA) VALUES ('1', '"+saldo_disponible+"', '"+estado_cuenta+"', '0', '"+tipo_cuenta+"') RETURNING numero_cuenta into :variable2";
                OracleParameter parametro1 = new OracleParameter("variable2", OracleType.Number);
                parametro1.Direction = ParameterDirection.Output;
                parametro1.Value = 0;
                comando.Parameters.Add(parametro1);
                comando.ExecuteNonQuery();
                var variable2 = comando.Parameters["variable2"].Value.ToString();
                
                //por cada cliente se relaciona con la cuenta 
                foreach (object obj_cuenta in flow_cuentas.Controls)
                {
                    TextBox box_cuenta = (TextBox)obj_cuenta;
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO CLIENTE_CUENTA(CLIENTE, CUENTA) VALUES(:cliente,:cuenta)";
                    OracleParameter cliente = new OracleParameter("cliente", OracleType.Number);
                    cliente.Value = box_cuenta.Text;
                    comando.Parameters.Add(cliente);
                    OracleParameter cuenta = new OracleParameter("cuenta", OracleType.Number);
                    cuenta.Value = variable2;
                    comando.Parameters.Add(cuenta);
                    comando.ExecuteNonQuery();
                }
                trans.Commit();
                System.Windows.Forms.MessageBox.Show("Se ha creado la cuenta exitosamente no."+variable2);
            }
            catch (DataException ex) {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error durante la transacción");
            }
            finally
            {
                ora.Close();
            }


            
           
        }

        private void ABC_CUENTA_Load(object sender, EventArgs e)
        {
            ora = new OracleConnection(
                "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
                "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
                "USER ID=" + Properties.Settings.Default.usuario_db + ";"
                );
        }
    }
}
