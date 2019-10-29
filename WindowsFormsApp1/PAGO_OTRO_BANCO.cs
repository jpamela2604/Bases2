using System;
using System.Collections;
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
    }
}
