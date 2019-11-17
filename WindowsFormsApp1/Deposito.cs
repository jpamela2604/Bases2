using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;

namespace WindowsFormsApp1
{
    public partial class Deposito : Form
    {
        public String conexion;
        public System.Data.IsolationLevel lectura;
        public System.Data.IsolationLevel escritura;
        public Deposito()
        {
            conexion = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
            lectura = IsolationLevel.ReadCommitted;
            escritura = IsolationLevel.ReadCommitted;
            InitializeComponent();
        }
        public Boolean validarNoCuenta(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo numero de cuenta debe ser llenado");
                return false;
            }
            return true;
        }
        public Boolean fillcamp(TextBox tb,String mensaje)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo "+mensaje+" debe ser llenado");
                return false;
            }
            return true;
        }
        public Boolean validarMonto(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("El campo monto debe ser llenado");
                return false;
            }
            return true;
        }
        bool ComprobarCuenta(String ctaa)
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("validar_cuenta", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("cuent", OracleType.Number).Value = Convert.ToInt32(ctaa);
                    comando.Parameters.Add("resultado", OracleType.Number);
                    comando.Parameters["resultado"].Direction = ParameterDirection.ReturnValue;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    /*ASIGNAR A VARIABLE DE CONFIGURACION*/
                    var codigoRol = Convert.ToString(comando.Parameters["resultado"].Value);
                    return true;
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Cuenta inexistente");
                    transaction.Rollback();
                    return false;
                }
            }
        }
        private void NumeroCuenta_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumeroCuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                NumeroCuenta.Text = NumeroCuenta.Text.Remove(NumeroCuenta.Text.Length - 1);
            }
        }

        private void Monto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Monto.Text, @"^[\d]*([.,][\d]*)?$"))
            {

            }
            else
            {
                MessageBox.Show("Ingrese solo numeros");
                Monto.Text = Monto.Text.Remove(Monto.Text.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void txt_nocuenta_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_nocuenta.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                txt_nocuenta.Text = txt_nocuenta.Text.Remove(txt_nocuenta.Text.Length - 1);
            }
        }

        private void txt_nocheque_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_nocheque.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                txt_nocheque.Text = txt_nocheque.Text.Remove(txt_nocheque.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtnocheque.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                txtnocheque.Text = txtnocheque.Text.Remove(txtnocheque.Text.Length - 1);
            }
        }

        private void txt_monto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_monto.Text, @"^[\d]*([.,][\d]*)?$"))
            {

            }
            else
            {
                MessageBox.Show("Ingrese solo numeros");
                txt_monto.Text = txt_monto.Text.Remove(txt_monto.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtmonto.Text, @"^[\d]*([.,][\d]*)?$"))
            {

            }
            else
            {
                MessageBox.Show("Ingrese solo numeros");
                txtmonto.Text = txtmonto.Text.Remove(txtmonto.Text.Length - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login principal = new Login();
            principal.Show();
        }

        private void monetario_Click(object sender, EventArgs e)
        {
            if(!(validarNoCuenta(NumeroCuenta)&&validarMonto(Monto)&&ComprobarCuenta(NumeroCuenta.Text)))
            {
                return;
            }



            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("deposito", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(escritura);
                comando.Transaction = transaction;
                OracleConnection ora = new OracleConnection(conexion);
                try
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("fech", OracleType.Timestamp).Value =DateTime.Now;
                    comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDecimal(Monto.Text);
                    comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                    comando.Parameters.Add("agencia", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.Parameters.Add("cuen", OracleType.Number).Value = Convert.ToInt32(NumeroCuenta.Text);
                    comando.Parameters.Add("equipo", OracleType.Number).Value = Properties.Settings.Default.agencia;
                    comando.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se hizo el deposito correctamente");
                    NumeroCuenta.Text = "";
                    Monto.Text = "";

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("Algo fallo");
                }

            }
        }

        private void local_Click(object sender, EventArgs e)
        {
            if (!(validarNoCuenta(textBox1)
                && fillcamp(txt_nocuenta,"No Cuenta del cheque")
                && fillcamp(txt_nocheque,"Numero de cheque")
                && validarMonto(txt_monto)
                && ComprobarCuenta(textBox1.Text)))
            {
                return;
            }

            OracleConnection ora= new OracleConnection(
               "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
               "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
               "USER ID=" + Properties.Settings.Default.usuario_db + ";"
               );
            OracleDataAdapter adaptador;
            OracleCommand comando;
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            OracleTransaction trans = ora.BeginTransaction();
            comando.Transaction = trans;
            try
            {
                //VERIFICACION INICIAL DEL CHEQUE
                comando.CommandText = "select estado_cheque from cheque_local where codigo_cheque = :cheque";
                comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                OracleDataReader dr = comando.ExecuteReader();
                //dr.Read();
                if (dr.Read())
                {
                    Int32 estado_chequera = Convert.ToInt32(dr["estado_cheque"]);
                    String mensaje = "";
                    if (estado_chequera == 5)
                    {
                        mensaje = "rechazado";
                    }
                    else if (estado_chequera == 4)
                    {
                        mensaje = "cobrado";
                    }
                    else if (estado_chequera == 3)
                    {
                        mensaje = "robado";
                    }
                    else if (estado_chequera == 2)
                    {
                        mensaje = "extraviado";
                    }
                    System.Windows.Forms.MessageBox.Show("Error el cheque aparece: " + mensaje);
                    return;
                }

                //VERIFICAR EL CHEQUE
                comando.Parameters.Clear();
                bool verif_cheq = false;
                Int32 chequera = 0;
                Int32 cod_cheque = Convert.ToInt32(txt_nocheque.Text);
                comando.CommandText = "SELECT * FROM chequera WHERE cuenta = :cuenta";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                dr = comando.ExecuteReader();
                //dr.Read();
                while (!verif_cheq && dr.Read())
                {
                    //CHEQUE PERTENEZCA A CHEQUERA
                    if (cod_cheque >= Convert.ToInt32(dr["numero_inicio"]) && cod_cheque <= Convert.ToInt32(dr["numero_final"]))
                    {
                        verif_cheq = true;
                        chequera = Convert.ToInt32(dr["codigo_chequera"]);
                    }
                    //dr.NextResult();
                }

                if (!verif_cheq)
                {
                    //RECHAZAR CHEQUE
                    System.Windows.Forms.MessageBox.Show("El cheque no pertenece a ninguna chequera o a esa cuenta");
                    return;
                }

                //VERIFICA EL SALDO
                comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                dr = comando.ExecuteReader();
                dr.Read();
                Int32 saldo = Convert.ToInt32(dr["saldo_disponible"]);
                double monto = Convert.ToDouble(txt_monto.Text);
                DateTime fecha = DateTime.Now;
                //.ToString("MM/dd/yyyy hh:mm:ss tt")
                if (saldo < monto)
                {
                    System.Windows.Forms.MessageBox.Show("Saldo Insuficiente");
                    //RECHAZAR CHEQUE
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                        "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                    comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = cod_cheque;
                    comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                    comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                    comando.Parameters.Add("chequera", OracleType.Number).Value = chequera;
                    comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 5;
                    comando.ExecuteNonQuery();

                    //GRABAR TRANSACCION
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO TRANSACCION (NO_RECHAZO, RAZON_RECHAZO, FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                        "VALUES(:rechazo, :razon,:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'0',:equipo,:cheque)";
                    comando.Parameters.Add("rechazo", OracleType.Number).Value = 1;
                    comando.Parameters.Add("razon", OracleType.VarChar).Value = "NO TIENE FONDOS";
                    comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                    comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                    comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                    comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                    comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                    comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                    comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                    comando.ExecuteNonQuery();
                    return;
                }

                //SE DEBITA DE LA CUENTA
                comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible - :monto WHERE numero_cuenta = :cuenta";
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.ExecuteNonQuery();

                //CHEQUE COBRADO
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                        "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = cod_cheque;
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("chequera", OracleType.Number).Value = chequera;
                comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 4;
                comando.ExecuteNonQuery();

                //SE REGISTRA LA TRANSACCION
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, CUENTA,TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,:cuenta,'0',:equipo,:cheque)";
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(txt_monto.Text);
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(txt_nocheque.Text);
                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                comando.ExecuteNonQuery();
                // se registra el deposito
                comando.Parameters.Clear();
                String upd= "update cuenta set saldo_disponible =(select saldo_disponible from cuenta where NUMERO_CUENTA=" + textBox1.Text + ")+" + txt_monto.Text + "  where NUMERO_CUENTA=" + textBox1.Text + "";
                comando.CommandText = upd;
                //MessageBox.Show(upd);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            comando.CommandText = "insert into transaccion (fecha,saldo_inicial,saldo_final,valor,empleado,agencia,cuenta,tipo_transaccion,equipo,cheque_local) values (:fecha,0,0," + Convert.ToDecimal(txt_monto.Text) + "," + Properties.Settings.Default.empleado + "," + Properties.Settings.Default.agencia + "," + textBox1.Text + "," + 1 + "," + Properties.Settings.Default.agencia +","+txt_nocheque.Text+ ")";
            comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
           
            comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("se ha realizado la operacion exitosamente");
               

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                trans.Commit();
                ora.Close();
            }
        }

        private void externo_Click(object sender, EventArgs e)
        {
            if (!(validarNoCuenta(textBox2)
                && fillcamp(txtnocheque, "Numero de cheque")
                && validarMonto(txtmonto)
                && ComprobarCuenta(textBox2.Text)))
            {
                return;
            }
            OracleConnection ora = new OracleConnection(
              "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
              "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
              "USER ID=" + Properties.Settings.Default.usuario_db + ";"
              );
            OracleDataAdapter adaptador;
            OracleCommand comando;
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
                comando.Parameters.Add("cuenta", OracleType.Number).Value = txtnocuenta.Text;
                comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = txtnocheque.Text;
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                comando.Parameters.Add("monto", OracleType.Number).Value = txtmonto.Text;
                comando.Parameters.Add("banco", OracleType.Number).Value = Convert.ToInt32(combo_bank.SelectedValue.ToString());
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
                // se registra el deposito
                comando.Parameters.Clear();
                String upd = "update cuenta set en_reserva =(select en_reserva from cuenta where NUMERO_CUENTA=" + textBox2.Text + ")+" + txtmonto.Text + "  where NUMERO_CUENTA=" + textBox2.Text + "";
                comando.CommandText = upd;
                //MessageBox.Show(upd);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.CommandText = "insert into transaccion (fecha,saldo_inicial,saldo_final,valor,empleado,agencia,cuenta,tipo_transaccion,equipo,cheque_local) values (:fecha,0,0," 
                    + Convert.ToDecimal(txtmonto.Text) + "," + Properties.Settings.Default.empleado + "," + Properties.Settings.Default.agencia + "," + textBox2.Text + "," + 1 + "," + Properties.Settings.Default.agencia + "," + txtnocheque.Text + ")";
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                trans.Commit();
                System.Windows.Forms.MessageBox.Show("Operacion Realizada con Exito");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void btn_verif_Click(object sender, EventArgs e)
        {
            if (! fillcamp(txt_nocuenta, "No Cuenta del cheque"))
            {
                return;
            }
            OracleConnection ora;
            ora = new OracleConnection(
               "DATA SOURCE = " + Properties.Settings.Default.nombre_db + ";" +
               "PASSWORD=" + Properties.Settings.Default.contrasenia_db + ";" +
               "USER ID=" + Properties.Settings.Default.usuario_db + ";"
               );
            OracleDataAdapter adaptador;
            OracleCommand comando;
            ora.Open();
            try
            {
                comando = new OracleCommand();
                comando.Connection = ora;
                comando.CommandText = "SELECT firma FROM CLIENTE WHERE codigo_cliente = (SELECT cliente FROM CLIENTE_CUENTA WHERE cuenta = :cuenta)";
                comando.Parameters.Add("cuenta", OracleType.Number).Value = Convert.ToInt32(txt_nocuenta.Text);
                OracleDataReader dr = comando.ExecuteReader();
                dr.Read();
                ABC_CLIENTE b = new ABC_CLIENTE();
                byte[] firma = (byte[])(dr["firma"]);
                String ruta = b.convert_blob_to_image(firma, "firma");
                pic_firma.Image = Image.FromFile(ruta);
                this.local.Enabled = true;
            }
            catch (Exception ex)
            {
                this.local.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Debe ingresar un numero de cuenta valido");
            }
            finally
            {
                ora.Close();
            }
        }

        private void Deposito_Load(object sender, EventArgs e)
        {
            cargar_bancos();
        }

        void cargar_bancos()
        {
            using (OracleConnection connection = new OracleConnection(conexion))
            {
                connection.Open();
                OracleCommand comando = new OracleCommand("banco_select", connection);
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(lectura);
                comando.Transaction = transaction;
                try
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                    OracleDataAdapter adaptador = new OracleDataAdapter();
                    adaptador.SelectCommand = comando;
                    transaction.Commit();
                    DataTable tabla1 = new DataTable();
                    adaptador.Fill(tabla1);
                    combo_bank.DataSource = tabla1;
                    combo_bank.DisplayMember = "NOMBRE";
                    combo_bank.ValueMember = "ID_BANCO";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("algo salio mal");
                    transaction.Rollback();
                }
            }
        }
    }
}
