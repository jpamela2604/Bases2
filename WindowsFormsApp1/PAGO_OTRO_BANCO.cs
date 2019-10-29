using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PAGO_OTRO_BANCO : Form
    {
        OracleConnection ora;
        OracleDataAdapter adaptador;
        OracleCommand comando;
        Dictionary<string, string> test = new Dictionary<string, string>();

        public PAGO_OTRO_BANCO()
        {
            InitializeComponent();
        }

        private void PAGO_OTRO_BANCO_Load(object sender, EventArgs e)
        {
            ora = new OracleConnection(
                "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
                "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
                "USER ID=" + Properties.Settings.Default.usuario_db + ";"
                );

            ArrayList t_cuenta = Get_Bank();

            foreach (String[] tipo in t_cuenta)
            {
                test.Add(tipo[0],tipo[1]);
            }

            combo_bank.DataSource = new BindingSource(test, null);
            combo_bank.DisplayMember = "Value";
            combo_bank.ValueMember = "Key";
            combo_bank.SelectedIndex = 1;

            combo_makebank.DataSource = new BindingSource(test, null);
            combo_makebank.DisplayMember = "Value";
            combo_makebank.ValueMember = "Key";
            combo_makebank.SelectedIndex = 1;

        }

        private ArrayList Get_Bank() {
            ArrayList bank_list = new ArrayList();

            try
            {
                ora.Open();
                comando = new OracleCommand("SELECT id_banco, nombre FROM banco", ora);
                adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla_tipos = new DataTable();
                adaptador.Fill(tabla_tipos);

                foreach (DataRow row in tabla_tipos.Rows)
                {
                    String[] s1 = new String[3];
                    s1[0] = row["id_banco"].ToString();
                    s1[1] = row["nombre"].ToString();
                    bank_list.Add(s1);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error al buscar los bancos: " + e.Message);
            }
            finally
            {
                ora.Close();
            }

            return bank_list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            OracleTransaction trans = ora.BeginTransaction();
            comando.Transaction = trans;

            try
            {
                DateTime fecha = DateTime.Now;
                //CARGAR LOS DATOS A CHEQUES EXTERNOS
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO cheque_externo (codigo_cheque,fecha,cuenta,monto,banco,estado_cheque)" +
                    "VALUES (:codigo_cheque, :fecha,:cuenta,:monto,:banco,'7')";
                comando.Parameters.Add("cuenta",OracleType.Number).Value = txtnocuenta.Text;
                comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = txtnocheque.Text;
                comando.Parameters.Add("fecha",OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("monto", OracleType.Number).Value = txtmonto.Text;
                comando.Parameters.Add("banco",OracleType.Number).Value = ((KeyValuePair<string, string>)combo_bank.SelectedItem).Key;
                comando.ExecuteNonQuery();

                //CARGAR LOS DATOS A LA TRANSACCION
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO TRANSACCION " +
                    "      (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, TIPO_TRANSACCION, EQUIPO,CHEQUE_EXTERNO) " +
                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,'2',:equipo,:cheque)";
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txtmonto.Text);
                comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txtnocheque.Text);
                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                comando.ExecuteNonQuery();
                trans.Commit();
                System.Windows.Forms.MessageBox.Show("Operacion Realizada con Exito");
            }
            catch(Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT nombre,descripcion FROM estado_cheque WHERE " +
                    "codigo = (SELECT estado_cheque from cheque_externo WHERE codigo_cheque = :cheque )";
                comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                if (dr.IsDBNull(1))
                {
                    System.Windows.Forms.MessageBox.Show("No se pudo encontrar el cheque");
                    return;
                }
                String descp = (String)dr["nombre"];
                lbl_nombre.Text = descp;
                lbl_descripcion.Text = (String)dr["descripcion"];
                if (descp == "pendiente")
                {
                    btn_cobrar.Enabled = true;
                }
                else
                {
                    btn_cobrar.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void bnt_generar_Click(object sender, EventArgs e)
        {
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT codigo_cheque,fecha,monto,banco,cuenta FROM cheque_externo WHERE estado_cheque = 7 and banco = :banco";
                comando.Parameters.Add("banco", OracleType.Number).Value = ((KeyValuePair<string, string>)combo_bank.SelectedItem).Key;
                OracleDataReader dr = comando.ExecuteReader();                
                String createText = "";
                while (dr.Read())
                {
                    //BANCO|REFERENCIA|CUENTA|NO_CHEQUE|MONTO
                    createText += dr["banco"] + "|" + "000" + "|" + dr["cuenta"] + "|" + dr["codigo_cheque"] + "|" + dr["monto"];
                    createText += "\n";
                }
                //out_banco_correlativo.txt
                string path = Directory.GetCurrentDirectory() + "\\out_"+ ((KeyValuePair<string, string>)combo_bank.SelectedItem).Key+"_00.txt";
                File.WriteAllText(path, createText);
                System.Windows.Forms.MessageBox.Show("El archivo \n"+path+"\n se ha creado correctamente");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ora.Close();
            }
        }
    }
}
