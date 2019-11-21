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

        private void decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if ( !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void entero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
            if (txtnocuenta.Text == "") {System.Windows.Forms.MessageBox.Show("debe ingresar un numero de cuenta"); return;}
            if (txtmonto.Text == "") { System.Windows.Forms.MessageBox.Show("debe ingresar un monto"); return; }
            if (txtnocheque.Text == "") {System.Windows.Forms.MessageBox.Show("debe ingresar un numero de cheque"); return; }
            if (!double.TryParse(txtmonto.Text, out double test)){ System.Windows.Forms.MessageBox.Show("el monto no corresponde a un numero valido"); return; }

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
                comando.Parameters.Add("banco", OracleType.Number).Value = ((KeyValuePair<string, string>)combo_makebank.SelectedItem).Key;
                OracleDataReader dr = comando.ExecuteReader();                
                String createText = "";
                while (dr.Read())
                {
                    //BANCO|REFERENCIA|CUENTA|NO_CHEQUE|MONTO
                    createText += dr["banco"] + "|" + "000" + "|" + dr["cuenta"] + "|" + dr["codigo_cheque"] + "|" + dr["monto"];
                    createText += "\n";
                }
                //out_banco_correlativo.txt
                string path = Directory.GetCurrentDirectory() + "\\OUT_"+ ((KeyValuePair<string, string>)combo_makebank.SelectedItem).Key+"_00.txt";
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

        private void btn_conciliado_Click(object sender, EventArgs e)
        {
            //CARGAR ARCHIVO
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                //POR CADA REGISTRO HACER LO SIGUIENTE
                var lines = File.ReadLines(selectedFileName);
                String RESPUESTA = "";
                foreach (var line in lines)
                {
                    //BANCO|REFERENCIA|CUENTA|NO_CHEQUE|MONTO  
                    String[] linea = line.Split('|');
                    String estatus = "OK";
                    //String log = "";
                    //HACER COBRO DEL CHEQUE
                    ora.Open();
                    comando = new OracleCommand();
                    comando.Connection = ora;
                    OracleTransaction trans = ora.BeginTransaction();
                    comando.Transaction = trans;
                    DateTime fecha = DateTime.Now;
                    var chequera = 0;   
                    try
                    {
                        //VERIFICACION INICIAL DEL CHEQUE
                        comando.CommandText = "SELECT descripcion, nombre FROM estado_cheque WHERE codigo = (SELECT estado_cheque FROM cheque_local WHERE codigo_cheque = :cheque)";
                        comando.Parameters.Add("cheque", OracleType.Number).Value = linea[3];
                        OracleDataReader dr = comando.ExecuteReader();
                        //dr.Read();
                        if (dr.Read())
                        {
                            throw new Exception("Error el cheque aparece: " + dr["descripcion"] + " " + dr["nombre"]);
                        }

                        //EXISTE EL CHEQUE
                        comando.Parameters.Clear();
                        bool verif_cheq = false;
                        Int32 cod_cheque = Convert.ToInt32(linea[3]);
                        comando.CommandText = "SELECT * FROM chequera WHERE cuenta = :cuenta";
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = linea[2];
                        dr = comando.ExecuteReader();
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
                            throw new Exception("El cheque no pertenece a ninguna chequera o a esa cuenta");
                        }


                        //LA CUENTA TIENE FONDOS
                        comando.Parameters.Clear();
                        comando.CommandText = "SELECT saldo_disponible FROM cuenta WHERE numero_cuenta = :cuenta";
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = linea[2];
                        dr = comando.ExecuteReader();
                        dr.Read();
                        Int32 saldo = Convert.ToInt32(dr["saldo_disponible"]);
                        double monto = Convert.ToDouble(linea[4]);
                        if (saldo < monto)
                        {
                            throw new Exception("NO TIENE FONDOS");
                        }

                        //SE DEBITA DE LA CUENTA
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible - :monto WHERE numero_cuenta = :cuenta";
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = linea[2];
                        comando.Parameters.Add("monto", OracleType.Number).Value = Convert.ToDouble(linea[4]);
                        comando.ExecuteNonQuery();

                        //CHEQUE COBRADO
                        comando.Parameters.Clear();
                        comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                                "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                        comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = linea[3];
                        comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                        comando.Parameters.Add("monto", OracleType.Number).Value = linea[4];
                        comando.Parameters.Add("chequera", OracleType.Number).Value = chequera;
                        comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 4;
                        comando.ExecuteNonQuery();

                        //REGISTRAR LA TRANSACCION
                        comando.Parameters.Clear();
                        comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                            "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,'0',:equipo,:cheque)";
                        comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                        comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(linea[4]);
                        comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(linea[3]);
                        comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                        comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                        comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();

                        if (ex.Message == "NO TIENE FONDOS") {
                            //RECHAZAR CHEQUE
                            comando.Parameters.Clear();
                            comando.CommandText = "INSERT INTO CHEQUE_LOCAL (codigo_cheque,fecha,monto,chequera,estado_cheque)" +
                                "VALUES(:codigo_cheque,:fecha,:monto,:chequera,:estado_cheque)";
                            comando.Parameters.Add("codigo_cheque", OracleType.Number).Value = linea[3];
                            comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                            comando.Parameters.Add("monto", OracleType.Number).Value = linea[4];
                            comando.Parameters.Add("chequera", OracleType.Number).Value = chequera;
                            comando.Parameters.Add("estado_cheque", OracleType.Number).Value = 5;
                            comando.ExecuteNonQuery();
                        }

                        //REGISTRAR LA TRANSACCION
                        comando.Parameters.Clear();
                        comando.CommandText = "INSERT INTO TRANSACCION (NO_RECHAZO, RAZON_RECHAZO,FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, TIPO_TRANSACCION, EQUIPO,CHEQUE_LOCAL) " +
                            "VALUES(:norechazo,:razonrechazo,:fecha,'0','0',:valor,:empleado,:agencia,'0',:equipo,:cheque)";
                        comando.Parameters.Add("norechazo", OracleType.Number).Value = 1;
                        comando.Parameters.Add("razonrechazo", OracleType.Number).Value = ex.Message;
                        comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                        comando.Parameters.Add("valor", OracleType.Number).Value = Convert.ToDouble(linea[4]);
                        comando.Parameters.Add("cheque", OracleType.Number).Value = Convert.ToInt32(linea[3]);
                        comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                        comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                        comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                        comando.ExecuteNonQuery();
                        trans.Commit();
                        estatus = "1";
                    }
                    finally
                    {                        
                        //GRABAR EN LA VARIABLE DE RETORNO
                        RESPUESTA += line + "|" + estatus;
                        RESPUESTA += "\n";
                    }                    
                }
                //GUARDAR EL ARCHIVO 
                //IN_banco_correlativo.txt
                string path = Directory.GetCurrentDirectory() + "\\IN_2_00.txt";
                File.WriteAllText(path, RESPUESTA);
                System.Windows.Forms.MessageBox.Show("El archivo \n" + path + "\n se ha creado correctamente");
            }
        }

        private void btn_conciliar_Click(object sender, EventArgs e)
        {
            //CARGAR ARCHIVO
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ora.Open();
                comando = new OracleCommand();
                comando.Connection = ora;
                string selectedFileName = openFileDialog1.FileName;
                try
                {
                    //POR CADA REGISTRO HACER LO SIGUIENTE
                    var lines = File.ReadLines(selectedFileName);
                    foreach (var line in lines)
                    {
                        OracleTransaction trans = ora.BeginTransaction();
                        comando.Transaction = trans;
                        try
                        {
                            DateTime fecha = DateTime.Now;
                            //BANCO|REFERENCIA|CUENTA|NO_CHEQUE|MONTO|RESPONSE
                            String[] linea = line.Split('|');
                            if (linea[5].ToLower() == "ok")
                            {
                                //GRABAR TRANSACCION
                                comando.Parameters.Clear();
                                comando.CommandText = "INSERT INTO TRANSACCION (FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, TIPO_TRANSACCION, EQUIPO,CHEQUE_EXTERNO) " +
                                    "VALUES(:fecha,'0','0',:valor,:empleado,:agencia,'3',:equipo,:cheque)";
                                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                                comando.Parameters.Add("valor", OracleType.Number).Value = linea[4];
                                comando.Parameters.Add("cheque", OracleType.Number).Value = linea[3];
                                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                                comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                                comando.ExecuteNonQuery();

                                //  REGISTRAR CAMBIO EN CHEQUE_EXTRANGERO
                                comando.Parameters.Clear();
                                comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 8 WHERE codigo_cheque = :cheque";
                                comando.Parameters.Add("cheque", OracleType.Number).Value = linea[3];
                                comando.ExecuteNonQuery();
                                trans.Commit();
                            }
                            else
                            {
                                //GRABAR TRANSACCION
                                comando.Parameters.Clear();
                                comando.CommandText = "INSERT INTO TRANSACCION (NO_RECHAZO, RAZON_RECHAZO, FECHA,SALDO_INICIAL, SALDO_FINAL, VALOR,EMPLEADO, AGENCIA, TIPO_TRANSACCION, EQUIPO,CHEQUE_EXTERNO) " +
                                    "VALUES(:rechazo, :razon,:fecha,'0','0',:valor,:empleado,:agencia,'3',:equipo,:cheque)";
                                comando.Parameters.Add("rechazo", OracleType.Number).Value = 1;
                                comando.Parameters.Add("razon", OracleType.VarChar).Value = "NO TIENE FONDOS";
                                comando.Parameters.Add("fecha", OracleType.DateTime).Value = fecha;
                                comando.Parameters.Add("valor", OracleType.Number).Value = linea[4];
                                comando.Parameters.Add("cheque", OracleType.Number).Value = linea[3];
                                comando.Parameters.Add("empleado", OracleType.Number).Value = Properties.Settings.Default.empleado;
                                comando.Parameters.Add("agencia", OracleType.Number).Value = 1;
                                comando.Parameters.Add("equipo", OracleType.Number).Value = 0;
                                comando.ExecuteNonQuery();

                                //  REGISTRAR CAMBIO EN CHEQUE_EXTRANGERO
                                comando.Parameters.Clear();
                                comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 9 WHERE codigo_cheque = :cheque";
                                comando.Parameters.Add("cheque", OracleType.Number).Value = linea[3];
                                comando.ExecuteNonQuery();
                                trans.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    ora.Close();
                    System.Windows.Forms.MessageBox.Show("Se ha terminado de cargar el archivo "+ selectedFileName);
                }                
            }
        }

        private void btn_cobrar_Click(object sender, EventArgs e)
        {
            //cambiar el estado del cheque a cobrado
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 4 WHERE codigo_cheque = :cheque";
                comando.Parameters.Add("cheque", OracleType.Number).Value = txt_nocheque.Text;
                comando.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Operacion realizada con exito!");
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ora.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void combo_makebank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //obtener el indice del banco
            var numero_banco = ((KeyValuePair<string, string>)combo_makebank.SelectedItem).Key;
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "select * from cheque_externo, transaccion " +
                    " where " +
                    " cheque_externo.estado_cheque = 7 and " +
                    " transaccion.tipo_transaccion = 2 and " +
                    " transaccion.cheque_externo = cheque_externo.codigo_cheque and" +
                    " cheque_externo.cuenta is not null and" +
                    " cheque_externo.banco = :banco";
                comando.Parameters.Add("banco", OracleType.Number).Value = numero_banco;
                var reader = comando.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                dataGridView2.DataSource = t;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "select * from cheque_externo, transaccion " +
                    " where " +
                    " cheque_externo.estado_cheque = 8 and " +
                    " transaccion.tipo_transaccion = 2 and " +
                    " transaccion.cheque_externo = cheque_externo.codigo_cheque ";
                    //" cheque_externo.cuenta is not null";
                var reader = comando.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                dataGridView1.DataSource = t;

                comando.Parameters.Clear();
                comando.CommandText = "select * from cheque_externo, transaccion " +
                    " where " +
                    " cheque_externo.estado_cheque = 9 and " +
                    " transaccion.tipo_transaccion = 2 and " +
                    " transaccion.cheque_externo = cheque_externo.codigo_cheque ";
                    //" cheque_externo.cuenta is not null";
                reader = comando.ExecuteReader();
                DataTable t1 = new DataTable();
                t1.Load(reader);
                dataGridView3.DataSource = t1;
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

        private void button2_Click(object sender, EventArgs e)
        {
            ora.Open();
            comando = new OracleCommand();
            comando.Connection = ora;
            //por cada elemento de la tabla aceptado
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((row.Index + 1) == dataGridView1.Rows.Count) { break; }
                OracleTransaction trans = ora.BeginTransaction();
                comando.Transaction = trans;
                var cuenta = row.Cells["cuenta1"].Value.ToString();
                var monto = row.Cells["monto"].Value;
                var cheque = row.Cells["cheque_externo"].Value;
                try
                {                    
                    if (cuenta == "")
                    {
                        //si no tiene cuenta solo se cambia el estado del cheque
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 6 WHERE codigo_cheque = :cheque";
                        comando.Parameters.Add("cheque", OracleType.Number).Value = cheque;
                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        //restar monto a reserva
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cuenta SET en_reserva = en_reserva - :valor WHERE numero_cuenta = :cuenta";
                        comando.Parameters.Add("valor", OracleType.Number).Value = monto;
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = cuenta;
                        comando.ExecuteNonQuery();
                        //agregra monto a saldo disponible
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cuenta SET saldo_disponible = saldo_disponible + :valor WHERE numero_cuenta = :cuenta";
                        comando.Parameters.Add("valor", OracleType.Number).Value = monto;
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = cuenta;
                        comando.ExecuteNonQuery();
                        //se cambia el estado del cheque
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 4 WHERE codigo_cheque = :cheque";
                        comando.Parameters.Add("cheque", OracleType.Number).Value = cheque;
                        comando.ExecuteNonQuery();
                    }
                    trans.Commit();
                }catch(Exception ex)
                {
                    trans.Rollback();
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            //por cada elemento de la tabla rechazado
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if ((row.Index + 1) == dataGridView3.Rows.Count) { break; }
                OracleTransaction trans = ora.BeginTransaction();
                comando.Transaction = trans;
                var cuenta = row.Cells["cuenta1"].Value;
                var monto = row.Cells["monto"].Value;
                var cheque = row.Cells["cheque_externo"].Value;
                try
                {
                    if (cuenta == "")
                    {
                        //si no tiene cuenta solo se cambia el estado del cheque
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 5 WHERE codigo_cheque = :cheque";
                        comando.Parameters.Add("cheque", OracleType.Number).Value = cheque;
                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        //restar monto a reserva
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cuenta SET en_reserva = en_reserva - :valor WHERE numero_cuenta = :cuenta";
                        comando.Parameters.Add("valor", OracleType.Number).Value = monto;
                        comando.Parameters.Add("cuenta", OracleType.Number).Value = cuenta;
                        comando.ExecuteNonQuery();
                        //se cambia el estado del cheque
                        comando.Parameters.Clear();
                        comando.CommandText = "UPDATE cheque_externo SET estado_cheque = 5 WHERE codigo_cheque = :cheque";
                        comando.Parameters.Add("cheque", OracleType.Number).Value = cheque;
                        comando.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

            System.Windows.Forms.MessageBox.Show("Operacion completada!");
            ora.Close();
        }
    }
}
