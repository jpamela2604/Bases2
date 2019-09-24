using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ABC_CLIENTE : Form
    {
        OracleConnection ora;
        OracleDataAdapter adaptador;
        OracleCommand comando;
        Dictionary<string, string> test = new Dictionary<string, string>();

        public ABC_CLIENTE()
        {
            InitializeComponent();
        }

        private void ABC_CLIENTE_Load(object sender, EventArgs e)
        {
            ora = new OracleConnection(
                "DATA SOURCE = "+ Properties.Settings.Default.nombre_db + ";"+ 
                "PASSWORD="+ Properties.Settings.Default.contrasenia_db + ";"+
                "USER ID="+ Properties.Settings.Default.usuario_db + ";"
                );
            /*try
            {
                ora.Open();
                System.Windows.Forms.MessageBox.Show("conexion exitosa");
                Properties.Settings.Default.empleado = "Hola";
                Properties.Settings.Default.Save();
                var mensaje = Properties.Settings.Default.empleado;
                System.Windows.Forms.MessageBox.Show(mensaje);
                Properties.Settings.Default.empleado = "Adios";
                Properties.Settings.Default.Save();
                mensaje = Properties.Settings.Default.empleado;
                System.Windows.Forms.MessageBox.Show(mensaje);
                ora.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("conexion fallida");
            }*/

            ArrayList t_cuenta = Get_Tipes_Client();

            foreach (String[] tipo in t_cuenta)
            {
                test.Add(tipo[0], tipo[1] + " -- " + tipo[2]);
            }

            combo_tipo.DataSource = new BindingSource(test, null);
            combo_tipo.DisplayMember = "Value";
            combo_tipo.ValueMember = "Key";

            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
        }

        private ArrayList Get_Tipes_Client() {
            ArrayList tipos_usuario = new ArrayList();            
            try
            {
                ora.Open();
                comando = new OracleCommand("select codigo_tipo, tipo, descripcion from TIPO_CLIENTE", ora);
                adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla_tipos = new DataTable();
                adaptador.Fill(tabla_tipos);

                foreach (DataRow row in tabla_tipos.Rows)
                {
                    String[] s1 = new String[3];
                    s1[0] = row["codigo_tipo"].ToString();
                    s1[1] = row["tipo"].ToString();
                    s1[2] = row["descripcion"].ToString();
                    tipos_usuario.Add(s1);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error al buscar los tipos de cliente: " + e.Message);
            }
            finally {
                ora.Close();
            }
            
            return tipos_usuario;
        }

        public byte[] convert_image_to_blob(String path) {
            System.IO.FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return photo;
        }

        public String convert_blob_to_image(byte[] blob,String nombre) {
            File.WriteAllBytes(@"C:\"+nombre+".jpg", blob);
            return @"C:\"+nombre+".jpg";
        }

        public String[] Get_Client(int codigo_cliente ,int dpi) {
            String[] s1 = new String[9];
            DataTable tabla_tipos = new DataTable();
            try
            {
                ora.Open();
                if (codigo_cliente != 0)
                {
                    comando = new OracleCommand("SELECT * from CLIENTE where codigo_cliente = " + codigo_cliente);
                    adaptador = new OracleDataAdapter();
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(tabla_tipos);
                }
                else
                {
                    comando = new OracleCommand("SELECT * from CLIENTE where dpi = " + dpi);
                    adaptador = new OracleDataAdapter();
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(tabla_tipos);
                }
            }
            catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("se produjo un error: " + e.Message);
            }
            finally
            {
                ora.Close();
            }

            foreach (DataRow row in tabla_tipos.Rows)
            {
                s1[0] = row["codigo_cliente"].ToString();
                s1[1] = row["nombre"].ToString();
                s1[2] = row["direccion"].ToString();
                s1[3] = row["nit"].ToString();
                s1[4] = row["telefono"].ToString();
                s1[5] = row["correo"].ToString();
                s1[6] = row["tipo_cliente"].ToString();
                byte[] foto = Convert.FromBase64String(row["foto"].ToString());
                s1[7] = convert_blob_to_image(foto,"foto");
                byte[] firma = Convert.FromBase64String(row["firma"].ToString());
                s1[7] = convert_blob_to_image(firma, "firma");
                s1[9] = row["dpi"].ToString();
                break;
            }

            return s1;
        }

        private int Add_Client(String nombre, String direccion, int nit, int telefono, String correo, int tipo_cliente, byte[] foto, byte[] firma, String dpi) {
            int codigo_cliente = -1;
            try
            {
                ora.Open();
                comando = new OracleCommand("INSERT INTO CLIENTE (NOMBRE, DIRECCION, NIT, TELEFONO, CORREO, TIPO_CLIENTE,FOTO,FIRMA, DPI)" +
                    "VALUES ('" + nombre + "','" + direccion + "','" + nit + "','" + telefono + "','" + correo + "','" + tipo_cliente + "',:iFOTO,:iFIRMA,'" + dpi + "')",ora);

                OracleParameter iFOTO = comando.Parameters.Add(":iFOTO", OracleType.Blob);
                iFOTO.Value = foto;

                OracleParameter iFIRMA = comando.Parameters.Add(":iFIRMA", OracleType.Blob);
                iFIRMA.Value = firma;

                comando.ExecuteNonQuery();
                
                comando = new OracleCommand("SELECT codigo_cliente from CLIENTE where dpi = "+dpi,ora);
                adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla_tipos = new DataTable();
                adaptador.Fill(tabla_tipos);
                foreach (DataRow row in tabla_tipos.Rows)
                {
                    codigo_cliente = System.Convert.ToInt32(row["codigo_cliente"].ToString());
                    break;
                }
                System.Windows.Forms.MessageBox.Show("Operacion exitosa, su codigo de cliente: " + codigo_cliente);
            }
            catch (Exception e )
            {
                System.Windows.Forms.MessageBox.Show("se produjo un error: " + e.Message);
            }
            finally
            {
                ora.Close();
            }
            return codigo_cliente;
        }

        private void Remove_Client(int codigo)
        {
            try
            {
                ora.Open();
                comando = new OracleCommand("DELETE * from CLIENTE where codigo_cliente = "+codigo);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Operacion exitosa, se ha removido el cliente " + codigo);
            }
            catch(Exception e)
            {            
                System.Windows.Forms.MessageBox.Show("se produjo un error: "+e.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void Edit_Client(int codigo_cliente, String nombre, String direccion, int nit, int telefono, String correo, int tipo_cliente, byte[] foto, byte[] firma, String dpi)
        {
            try
            {
                ora.Open();
                comando = new OracleCommand("UPDATE CLIENTE " +
                    "SET nombre = "+nombre+"," +
                    "SET direccion = "+direccion+"," +
                    "SET nit = "+nit+"," +
                    "SET telefono = "+telefono+"," +
                    "SET correo = "+correo+"," +
                    "SET TIPO_CLIENTE = "+tipo_cliente+"," +
                    "SET foto = "+foto+"," +
                    "SET firma = "+firma+"," +
                    "SET dpi = "+dpi
                    +"WHERE codigo_cliente = "+codigo_cliente);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Operacion exitosa, se han actualizado los datos del cliente : " + codigo_cliente);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("se produjo un error: " + e.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Subir Foto";
            openFileDialog1.DefaultExt = "jpg";
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                box_foto.Text = openFileDialog1.FileName;
                pic_foto.Image = Image.FromFile(box_foto.Text);
                pic_foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Subir Firma";
            openFileDialog1.DefaultExt = "jpg";
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                box_firma.Text = openFileDialog1.FileName;
                pic_firma.Image = Image.FromFile(box_firma.Text);
                pic_firma.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void but_enviar_Click(object sender, EventArgs e)
        {
            if (!IsValidNit(box_nit.Text)) { System.Windows.Forms.MessageBox.Show("el verificador no puede validar su numero de nit, ingrese un nit valido"); return; }

            if (box_dpi.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el dpi"); return; }
            if (box_nombre.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el nombre"); return; }
            if (box_direccion.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en la direccion"); return; }
            if (box_nit.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion el nit"); return; }
            if (box_telefono.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el telefono"); return; }
            if (box_correo.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el correo"); return; }
            if (combo_tipo.Text == "") { System.Windows.Forms.MessageBox.Show("debe seleccionar un tipo de cliente"); return; }
            if (box_foto.Text == "") { System.Windows.Forms.MessageBox.Show("debe agregar una foto"); return; }
            if (box_firma.Text == "") { System.Windows.Forms.MessageBox.Show("debe agregar una firma"); return; }
            
            if (box_dpi.Text.Length != 13) { System.Windows.Forms.MessageBox.Show("la cantidad de digitos no corresponde a un dpi valido"); return; }
            if (box_telefono.Text.Length != 8) { System.Windows.Forms.MessageBox.Show("la cantidad de digitos no corresponde a un telefono valido"); return; }

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(box_correo.Text);
            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("formato invalido de correo electronico");
                return;
            }

            byte[] foto = convert_image_to_blob(box_foto.Text);
            byte[] firma = convert_image_to_blob(box_firma.Text);
            string tipo_cliente = ((KeyValuePair<string, string>)combo_tipo.SelectedItem).Key;

            int resultado = Add_Client(box_nombre.Text, box_direccion.Text, Int32.Parse(box_nit.Text), Int32.Parse(box_telefono.Text), box_correo.Text, Int32.Parse(tipo_cliente), foto, firma, box_dpi.Text);
            if(resultado != -1)
            {
                box_dpi.Text = "";
                box_nombre.Text = "";
                box_direccion.Text = "";
                box_nit.Text = "";
                box_telefono.Text = "";
                box_correo.Text = "";
                box_foto.Text = "";
                pic_foto.Image = null;
                box_firma.Text = "";
                pic_firma.Image = null;
            }
        }

        private bool IsValidNit(string nit)
        {
            if (nit == null)
                throw new ArgumentNullException(nameof(nit));
            if (nit.Length != 7)
                return false;
            var digitos = new byte[7];
            for (int i = 0; i < nit.Length; i++)
            {
                if (!char.IsDigit(nit[i]))
                    return false;
                digitos[i] = byte.Parse(nit[i].ToString());
            }
            var v = 7 * digitos[0] +
                    6 * digitos[1] +
                    5 * digitos[2] +
                    4 * digitos[3] +
                    3 * digitos[4] +
                    2 * digitos[5]
                    ;
            v = v % 11;
            if (v >= 2)
                v = 11 - v;
            return v == digitos[6];
        }
    }
    
}
