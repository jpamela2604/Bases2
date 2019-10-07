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
            if (box_saldo.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar una cantidad inicial valida");
                return;
            }

            if (flow_cuentas.Controls.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar al menos una cuenta");
                return;
            }

            var saldo_disponible = box_saldo.Text;
            var estado_cuenta = 1;
            var tipo_cuenta = 1;
            if (flow_cuentas.Controls.Count > 1)
            {
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
                comando.CommandText = "INSERT INTO CUENTA (ESTADO, SALDO_DISPONIBLE, ESTADO_CUENTA, EN_RESERVA, TIPO_CUENTA) VALUES ('1', '" + saldo_disponible + "', '" + estado_cuenta + "', '0', '" + tipo_cuenta + "') RETURNING numero_cuenta into :variable2";
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
                    if(box_cuenta.Text == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Debe llenar cada una de las casillas con codigos validos");
                        throw new Exception();
                    }
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
                System.Windows.Forms.MessageBox.Show("Se ha creado la cuenta exitosamente no." + variable2);
            }
            catch (Exception ex)
            {
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {



            data_cuenta.DataSource = null;
            lbl_saldo_inicial.Text = "";
            lbl_tipo_cuenta.Text = "";

            if (box_find_cuenta.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar una cuenta");
                return;
            }

            ora.Open();
            try
            {
                var numero_cuenta = box_find_cuenta.Text;
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT * FROM CUENTA WHERE NUMERO_CUENTA = :numero_cuenta";
                OracleParameter param1 = new OracleParameter("numero_cuenta", OracleType.Number);
                param1.Value = numero_cuenta;
                comando.Parameters.Add(param1);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                lbl_saldo_inicial.Text = dr["SALDO_DISPONIBLE"].ToString();
                if (dr["TIPO_CUENTA"].ToString() == "1")
                {
                    lbl_tipo_cuenta.Text = "PERSONAL";
                }
                else
                {
                    lbl_tipo_cuenta.Text = "MANCOMUNADA";
                }

                if (dr["ESTADO_CUENTA"].ToString() == "1")
                {
                    lbl_estado_cuenta.Text = "activa";
                }
                else if (dr["ESTADO_CUENTA"].ToString() == "2")
                {
                    lbl_estado_cuenta.Text = "bloqueada";
                }
                else
                {
                    lbl_estado_cuenta.Text = "cancelada";
                }

                comando.CommandText = "SELECT CLIENTE FROM CLIENTE_CUENTA WHERE CUENTA = :numero_cuenta";
                OracleDataAdapter od = new OracleDataAdapter(comando);
                DataTable table = new DataTable();
                od.Fill(table);
                data_cuenta.DataSource = table;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("No se ha encontrado la cuenta solicitada");
            }
            finally
            {
                ora.Close();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btn_bloquear_Click(object sender, EventArgs e)
        {
            

            if (data_cuenta.DataSource == null)
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar una cuenta valida");
                return;
            }

            if (lbl_estado_cuenta.Text != "activa")
            {
                System.Windows.Forms.MessageBox.Show("La cuenta debe estar activa para poder bloquearse");
                return;
            }
            ora.Open();           

            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "UPDATE CUENTA SET ESTADO_CUENTA = '2' WHERE NUMERO_CUENTA = :cuenta";
                OracleParameter p1 = new OracleParameter("cuenta", OracleType.Number);
                p1.Value = box_find_cuenta.Text;
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Se ha bloqueado la cuenta " + box_find_cuenta.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ocurrio un error durante la operacion " + ex.Message);
            }
            finally
            {
                ora.Close();
            }
            btn_buscar_Click(null, null);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (data_cuenta.DataSource == null)
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar una cuenta valida");
                return;
            }

            if(lbl_estado_cuenta.Text == "cancelada")
            {
                System.Windows.Forms.MessageBox.Show("La cuenta ya ha sido cancelada");
                return;
            }

            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "UPDATE CUENTA SET ESTADO_CUENTA = '3' WHERE NUMERO_CUENTA = :cuenta";
                OracleParameter p1 = new OracleParameter("cuenta", OracleType.Number);
                p1.Value = box_find_cuenta.Text;
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Se ha cancelado la cuenta " + box_find_cuenta.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ocurrio un error durante la operacion " + ex.Message);
            }
            finally
            {
                ora.Close();
            }
            btn_buscar_Click(null, null);
        }

        private void btn_fcuentas_Click(object sender, EventArgs e)
        {
            if(box_codigo_fcuentas.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar un codigo de cliente");
                return;
            }
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT CUENTA FROM CLIENTE_CUENTA WHERE cliente =:codigo";
                OracleParameter p1 = new OracleParameter("codigo", OracleType.Number);
                p1.Value = box_codigo_fcuentas.Text;
                comando.Parameters.Add(p1);
                OracleDataAdapter od = new OracleDataAdapter(comando);
                DataTable t1 = new DataTable();
                od.Fill(t1);
                view_fcuentas.DataSource = t1;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("No se ha encontrado el cliente solicitado");
            }
            finally
            {
                ora.Close();
            }
        }

        private void btn_desbloquear_Click(object sender, EventArgs e)
        {
            if (data_cuenta.DataSource == null)
            {
                System.Windows.Forms.MessageBox.Show("Debe ingresar una cuenta valida");
                return;
            }

            if (lbl_estado_cuenta.Text != "bloqueada") {
                System.Windows.Forms.MessageBox.Show("La cuenta debe estar bloqueada para ser desbloqueada");
                return;
            }
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "UPDATE CUENTA SET ESTADO_CUENTA = '1' WHERE NUMERO_CUENTA = :cuenta";
                OracleParameter p1 = new OracleParameter("cuenta", OracleType.Number);
                p1.Value = box_find_cuenta.Text;
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Se ha desbloqueado la cuenta " + box_find_cuenta.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ocurrio un error durante la operacion " + ex.Message);
            }
            finally
            {
                ora.Close();
            }
            btn_buscar_Click(null, null);
        }
    }
}
