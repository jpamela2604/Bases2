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
                "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
                "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
                "USER ID=" + Properties.Settings.Default.usuario_db + ";"
                );

            ArrayList t_cuenta = Get_Tipes_Client();

            foreach (String[] tipo in t_cuenta)
            {
                test.Add(tipo[0], tipo[1] + " -- " + tipo[2]);
            }

            combo_tipo.DataSource = new BindingSource(test, null);
            combo_tipo.DisplayMember = "Value";
            combo_tipo.ValueMember = "Key";

            box_btipo.DataSource = new BindingSource(test, null);
            box_btipo.DisplayMember = "Value";
            box_btipo.ValueMember = "Key";
            combo_buscar.SelectedIndex = 1;
        }

        private ArrayList Get_Tipes_Client()
        {
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
            finally
            {
                ora.Close();
            }

            return tipos_usuario;
        }

        public byte[] convert_image_to_blob(String path)
        {
            System.IO.FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return photo;
        }

        public String convert_blob_to_image(byte[] blob, String nombre)
        {
            String path = Path.GetTempPath();
            String direccion = @path + nombre + ".jpg";
            if (File.Exists(direccion))
            {
                File.Delete(direccion);
            }
            File.WriteAllBytes(direccion, blob);
            return direccion;
        }

        public String[] Get_Client(long codigo_cliente,long dpi)
        {
            String[] s1 = new String[10];
            try
            {
                ora.Open();
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandType = CommandType.Text;
                OracleParameter parametro1;
                if (codigo_cliente != 0)
                {
                    comando.CommandText = "SELECT * from CLIENTE where codigo_cliente = :codigo_cliente";
                    parametro1 = new OracleParameter("codigo_cliente", OracleType.Number);
                    parametro1.Value = codigo_cliente;
                    comando.Parameters.Add(parametro1);
                }
                else
                {
                    comando.CommandText = "SELECT * from CLIENTE where dpi = :dpi";
                    parametro1 = new OracleParameter("dpi", OracleType.Number);
                    parametro1.Value = dpi;
                    comando.Parameters.Add(parametro1);
                }
                OracleDataReader lector = comando.ExecuteReader();
                lector.Read();

                if (lector.HasRows)
                {
                    s1[0] = lector.GetInt32(0).ToString(); //codigo cliente
                    s1[1] = lector.GetString(1); //nombre
                    s1[2] = lector.GetString(2); //direccion
                    s1[3] = lector.GetInt32(3).ToString(); //nit
                    s1[4] = lector.GetInt32(4).ToString(); //telefono
                    s1[5] = lector.GetString(5); //correo
                    s1[6] = lector.GetInt32(6).ToString(); //tipo_cliente
                    byte[] foto = (byte[])(lector["foto"]); //foto
                    s1[7] = convert_blob_to_image(foto, "foto"); //foto
                    byte[] firma = (byte[])(lector["firma"]); //firma
                    s1[8] = convert_blob_to_image(firma, "firma"); //firma
                    s1[9] = lector.GetString(9); //dpi   
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("se produjo un error: " + e.Message);
            }
            finally
            {
                ora.Close();
            }

            return s1;
        }

        private int Add_Client(String nombre, String direccion, int nit, int telefono, String correo, int tipo_cliente, byte[] foto, byte[] firma, String dpi)
        {
            int codigo_cliente = -1;
            try
            {
                ora.Open();
                comando = new OracleCommand("INSERT INTO CLIENTE (NOMBRE, DIRECCION, NIT, TELEFONO, CORREO, TIPO_CLIENTE,FOTO,FIRMA, DPI)" +
                    "VALUES ('" + nombre + "','" + direccion + "','" + nit + "','" + telefono + "','" + correo + "','" + tipo_cliente + "',:iFOTO,:iFIRMA,'" + dpi + "')", ora);

                OracleParameter iFOTO = comando.Parameters.Add(":iFOTO", OracleType.Blob);
                iFOTO.Value = foto;

                OracleParameter iFIRMA = comando.Parameters.Add(":iFIRMA", OracleType.Blob);
                iFIRMA.Value = firma;

                comando.ExecuteNonQuery();

                comando = new OracleCommand("SELECT codigo_cliente from CLIENTE where dpi = " + dpi, ora);
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("se produjo un error: " + e.Message);
            }
            finally
            {
                ora.Close();
            }
            return codigo_cliente;
        }

        private void Eliminar_Cliente(int codigo)
        {
            try
            {
                ora.Open();
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE FROM CLIENTE where codigo_cliente = :codigo_cliente";
                OracleParameter parametro1 = new OracleParameter("codigo_cliente", OracleType.Int32);
                parametro1.Value = codigo;
                comando.Parameters.Add(parametro1);
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Operacion exitosa, se ha removido el cliente " + codigo);
                box_bcodigo.Text = "";
                box_bdpi.Text = "";
                box_bnombre.Text = "";
                box_bdireccion.Text = "";
                box_btelefono.Text = "";
                box_bcorreo.Text = "";
                box_bnit.Text = "";
                box_bfirma.Text = "";
                box_bfoto.Text = "";
                pic_bfoto.Image = null;
                pic_bfirma.Image = null;
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

        private void Edit_Client(int codigo_cliente, String nombre, String direccion, int nit, int telefono, String correo, int tipo_cliente, byte[] foto, byte[] firma, String dpi)
        {
            try
            {
                ora.Open();
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                "UPDATE CLIENTE SET" +
                    " nombre = '" + nombre + "'," +
                    " direccion = '" + direccion + "'," +
                    " nit = '" + nit + "'," +
                    " telefono = '" + telefono + "'," +
                    " correo = '" + correo + "'," +
                    " TIPO_CLIENTE = '" + tipo_cliente + "'," +
                    " foto = :iFOTO," +
                    " firma = :iFIRMA," +
                    " dpi = '" + dpi + "'" +
                    " WHERE codigo_cliente = " + codigo_cliente;

                OracleParameter iFOTO = comando.Parameters.Add(":iFOTO", OracleType.Blob);
                iFOTO.Value = foto;

                OracleParameter iFIRMA = comando.Parameters.Add(":iFIRMA", OracleType.Blob);
                iFIRMA.Value = firma;

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
            if (resultado != -1)
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (pic_bfoto.Image != null)
            {
                pic_bfoto.Image.Dispose();
            }
            if (pic_bfirma.Image != null)
            {
                pic_bfirma.Image.Dispose();
            }

            if (box_cliente.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar un codigo o dpi valido"); return; }
            if (combo_buscar.Text == "") { System.Windows.Forms.MessageBox.Show("debe seleccionar una opcion valida"); return; }
            long codigo = System.Convert.ToInt64(box_cliente.Text);
            String opcion = combo_buscar.Text;
            String[] resultado;
            if (opcion == "CODIGO USUARIO")
            {
                resultado = Get_Client(codigo, 0);
            }
            else
            {
                resultado = Get_Client(0, codigo);
            }
            if (resultado[0] == null)
            {
                System.Windows.Forms.MessageBox.Show("No se encontro el "+combo_buscar.Text+": " + box_cliente.Text);
                return;
            }
            box_bcodigo.Text = resultado[0];//codigo de cliente
            box_bnombre.Text = resultado[1];//nombre
            box_bdireccion.Text = resultado[2];//direccion
            box_bnit.Text = resultado[3];//nit
            box_btelefono.Text = resultado[4];//telefono
            box_bcorreo.Text = resultado[5];//correo
            box_btipo.SelectedValue = resultado[6];//tipo_cliente
            box_bfoto.Text = resultado[7];
            box_bfirma.Text = resultado[8];
            box_bdpi.Text = resultado[9];//dpi
            pic_bfoto.Image = Image.FromFile(resultado[7]);
            pic_bfirma.Image = Image.FromFile(resultado[8]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (box_cliente.Text == "") {
                System.Windows.Forms.MessageBox.Show("Debe ingresar un codigo");
                return;
            }
            Eliminar_Cliente(System.Convert.ToInt32(box_bcodigo.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (box_bcodigo.Text == "") { System.Windows.Forms.MessageBox.Show("Debe buscar un codigo"); return; }
            if (!IsValidNit(box_bnit.Text)) { System.Windows.Forms.MessageBox.Show("el verificador no puede validar su numero de nit, ingrese un nit valido"); return; }
            if (box_bdpi.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el dpi"); return; }
            if (box_bnombre.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el nombre"); return; }
            if (box_bdireccion.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en la direccion"); return; }
            if (box_bnit.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion el nit"); return; }
            if (box_btelefono.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el telefono"); return; }
            if (box_bcorreo.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar informacion en el correo"); return; }
            if (combo_tipo.Text == "") { System.Windows.Forms.MessageBox.Show("debe seleccionar un tipo de cliente"); return; }
            if (box_bfoto.Text == "") { System.Windows.Forms.MessageBox.Show("debe agregar una foto"); return; }
            if (box_bfirma.Text == "") { System.Windows.Forms.MessageBox.Show("debe agregar una firma"); return; }
            if (box_bdpi.Text.Length != 13) { System.Windows.Forms.MessageBox.Show("la cantidad de digitos no corresponde a un dpi valido"); return; }
            if (box_btelefono.Text.Length != 8) { System.Windows.Forms.MessageBox.Show("la cantidad de digitos no corresponde a un telefono valido"); return; }

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(box_bcorreo.Text);
            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("formato invalido de correo electronico");
                return;
            }

            int codigo_cliente = System.Convert.ToInt32(box_bcodigo.Text);
            String nombre = box_bnombre.Text;
            String direccion = box_bdireccion.Text;
            int nit = System.Convert.ToInt32(box_bnit.Text);
            int telefono = System.Convert.ToInt32(box_btelefono.Text);
            String correo = box_bcorreo.Text;
            byte[] foto = convert_image_to_blob(box_bfoto.Text);
            byte[] firma = convert_image_to_blob(box_bfirma.Text);
            int tipo_cliente = System.Convert.ToInt32(((KeyValuePair<string, string>)combo_tipo.SelectedItem).Key);
            String dpi = box_bdpi.Text;
            Edit_Client(codigo_cliente, nombre, direccion, nit, telefono, correo, tipo_cliente, foto, firma, dpi);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Subir Foto";
            openFileDialog1.DefaultExt = "jpg";
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                box_bfoto.Text = openFileDialog1.FileName;
                pic_bfoto.Image = Image.FromFile(box_bfoto.Text);
                pic_bfoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Subir Firma";
            openFileDialog1.DefaultExt = "jpg";
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                box_bfirma.Text = openFileDialog1.FileName;
                pic_bfirma.Image = Image.FromFile(box_bfirma.Text);
                pic_bfirma.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void get_cliente_Click(object sender, EventArgs e)
        {

        }
    }

}
