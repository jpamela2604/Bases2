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
    public partial class Asignacion_Rol : Form
    {
        public Asignacion_Rol()
        {
            InitializeComponent();
            Conexion.abrirConexion();
            OracleCommand comando12 = new OracleCommand("empleado_select", Conexion.ora);
            comando12.CommandType = System.Data.CommandType.StoredProcedure;
            comando12.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador12 = new OracleDataAdapter();
            adaptador12.SelectCommand = comando12;
            DataTable tabla12 = new DataTable();
            adaptador12.Fill(tabla12);
            foreach (DataRow row in tabla12.Rows)
            {
                comboBox1.Items.Add(row[0] + "-" + row[1].ToString());
            }


            OracleCommand comando2 = new OracleCommand("rol_select", Conexion.ora);
            comando2.CommandType = System.Data.CommandType.StoredProcedure;
            comando2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = comando2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            foreach (DataRow row in tabla2.Rows)
            {
                comboBox2.Items.Add(row[0] + "-" + row[1].ToString());
            }
            Conexion.cerrarConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.abrirConexion();

            try
            {
                OracleCommand comando = new OracleCommand("empleado_update", Conexion.ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var id = comboBox1.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("pce", OracleType.VarChar).Value = id[0];
                var id2 = comboBox2.SelectedItem.ToString().Split('-');
                comando.Parameters.Add("id_rol", OracleType.VarChar).Value = id2[0];
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo");
            }


            Conexion.cerrarConexion();
        }
    }
}
