namespace WindowsFormsApp1
{
    partial class ABC_CUENTA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.box_saldo = new System.Windows.Forms.TextBox();
            this.btn_crear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flow_cuentas = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.box_find_cuenta = new System.Windows.Forms.TextBox();
            this.data_cuenta = new System.Windows.Forms.DataGridView();
            this.lbl_saldo_inicial = new System.Windows.Forms.Label();
            this.lbl_tipo_cuenta = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataSet1 = new System.Data.DataSet();
            this.btn_bloquear = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_estado_cuenta = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_fcuentas = new System.Windows.Forms.Button();
            this.box_codigo_fcuentas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.view_fcuentas = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_desbloquear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view_fcuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(806, 485);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.box_saldo);
            this.tabPage1.Controls.Add(this.btn_crear);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.flow_cuentas);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(798, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CREAR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // box_saldo
            // 
            this.box_saldo.Location = new System.Drawing.Point(152, 46);
            this.box_saldo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.box_saldo.Name = "box_saldo";
            this.box_saldo.Size = new System.Drawing.Size(132, 20);
            this.box_saldo.TabIndex = 8;
            this.box_saldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // btn_crear
            // 
            this.btn_crear.Location = new System.Drawing.Point(424, 370);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(80, 38);
            this.btn_crear.TabIndex = 7;
            this.btn_crear.Text = "Aceptar";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 183);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 4;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flow_cuentas
            // 
            this.flow_cuentas.AutoScroll = true;
            this.flow_cuentas.Location = new System.Drawing.Point(152, 141);
            this.flow_cuentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flow_cuentas.Name = "flow_cuentas";
            this.flow_cuentas.Size = new System.Drawing.Size(246, 150);
            this.flow_cuentas.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero(s) de cuenta";
            this.toolTip1.SetToolTip(this.label2, "Debe ingresar el numero de cliente al cual le pertenecerá la cuenta\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(43, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo inicial";
            this.toolTip1.SetToolTip(this.label1, "Debe ingresar un saldo para aperturar la cuenta");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_desbloquear);
            this.tabPage2.Controls.Add(this.lbl_estado_cuenta);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btn_cancelar);
            this.tabPage2.Controls.Add(this.btn_bloquear);
            this.tabPage2.Controls.Add(this.box_find_cuenta);
            this.tabPage2.Controls.Add(this.data_cuenta);
            this.tabPage2.Controls.Add(this.lbl_saldo_inicial);
            this.tabPage2.Controls.Add(this.lbl_tipo_cuenta);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_buscar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(798, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CONSULTAR";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // box_find_cuenta
            // 
            this.box_find_cuenta.Location = new System.Drawing.Point(227, 37);
            this.box_find_cuenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.box_find_cuenta.Name = "box_find_cuenta";
            this.box_find_cuenta.Size = new System.Drawing.Size(116, 20);
            this.box_find_cuenta.TabIndex = 12;
            this.box_find_cuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // data_cuenta
            // 
            this.data_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_cuenta.Location = new System.Drawing.Point(225, 194);
            this.data_cuenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.data_cuenta.Name = "data_cuenta";
            this.data_cuenta.RowTemplate.Height = 24;
            this.data_cuenta.Size = new System.Drawing.Size(232, 171);
            this.data_cuenta.TabIndex = 11;
            // 
            // lbl_saldo_inicial
            // 
            this.lbl_saldo_inicial.AutoSize = true;
            this.lbl_saldo_inicial.Location = new System.Drawing.Point(227, 145);
            this.lbl_saldo_inicial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_saldo_inicial.Name = "lbl_saldo_inicial";
            this.lbl_saldo_inicial.Size = new System.Drawing.Size(40, 13);
            this.lbl_saldo_inicial.TabIndex = 10;
            this.lbl_saldo_inicial.Text = "-----------";
            // 
            // lbl_tipo_cuenta
            // 
            this.lbl_tipo_cuenta.AutoSize = true;
            this.lbl_tipo_cuenta.Location = new System.Drawing.Point(225, 104);
            this.lbl_tipo_cuenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tipo_cuenta.Name = "lbl_tipo_cuenta";
            this.lbl_tipo_cuenta.Size = new System.Drawing.Size(40, 13);
            this.lbl_tipo_cuenta.TabIndex = 9;
            this.lbl_tipo_cuenta.Text = "-----------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cuenta Habientes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saldo inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Cuenta";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(400, 21);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(92, 50);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingrese numero de cuenta";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // btn_bloquear
            // 
            this.btn_bloquear.Location = new System.Drawing.Point(80, 403);
            this.btn_bloquear.Name = "btn_bloquear";
            this.btn_bloquear.Size = new System.Drawing.Size(97, 29);
            this.btn_bloquear.TabIndex = 13;
            this.btn_bloquear.Text = "Bloquear-Cuenta";
            this.btn_bloquear.UseVisualStyleBackColor = true;
            this.btn_bloquear.Click += new System.EventHandler(this.btn_bloquear_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(230, 403);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(97, 29);
            this.btn_cancelar.TabIndex = 14;
            this.btn_cancelar.Text = "Cancelar-Cuenta";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Estado de la cuenta";
            // 
            // lbl_estado_cuenta
            // 
            this.lbl_estado_cuenta.AutoSize = true;
            this.lbl_estado_cuenta.Location = new System.Drawing.Point(227, 74);
            this.lbl_estado_cuenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_estado_cuenta.Name = "lbl_estado_cuenta";
            this.lbl_estado_cuenta.Size = new System.Drawing.Size(40, 13);
            this.lbl_estado_cuenta.TabIndex = 16;
            this.lbl_estado_cuenta.Text = "-----------";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.view_fcuentas);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.box_codigo_fcuentas);
            this.tabPage3.Controls.Add(this.btn_fcuentas);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(798, 459);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BUSCAR CUENTAS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_fcuentas
            // 
            this.btn_fcuentas.Location = new System.Drawing.Point(401, 39);
            this.btn_fcuentas.Name = "btn_fcuentas";
            this.btn_fcuentas.Size = new System.Drawing.Size(113, 55);
            this.btn_fcuentas.TabIndex = 0;
            this.btn_fcuentas.Text = "Buscar cuentas";
            this.btn_fcuentas.UseVisualStyleBackColor = true;
            this.btn_fcuentas.Click += new System.EventHandler(this.btn_fcuentas_Click);
            // 
            // box_codigo_fcuentas
            // 
            this.box_codigo_fcuentas.Location = new System.Drawing.Point(249, 57);
            this.box_codigo_fcuentas.Name = "box_codigo_fcuentas";
            this.box_codigo_fcuentas.Size = new System.Drawing.Size(100, 20);
            this.box_codigo_fcuentas.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ingrese codigo de cliente";
            // 
            // view_fcuentas
            // 
            this.view_fcuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view_fcuentas.Location = new System.Drawing.Point(67, 176);
            this.view_fcuentas.Name = "view_fcuentas";
            this.view_fcuentas.Size = new System.Drawing.Size(294, 187);
            this.view_fcuentas.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Listado de cuentas";
            // 
            // btn_desbloquear
            // 
            this.btn_desbloquear.Location = new System.Drawing.Point(372, 403);
            this.btn_desbloquear.Name = "btn_desbloquear";
            this.btn_desbloquear.Size = new System.Drawing.Size(120, 29);
            this.btn_desbloquear.TabIndex = 17;
            this.btn_desbloquear.Text = "Desbloquear-Cuenta";
            this.btn_desbloquear.UseVisualStyleBackColor = true;
            this.btn_desbloquear.Click += new System.EventHandler(this.btn_desbloquear_Click);
            // 
            // ABC_CUENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 503);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ABC_CUENTA";
            this.Text = "ABC_CUENTA";
            this.Load += new System.EventHandler(this.ABC_CUENTA_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view_fcuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flow_cuentas;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_saldo_inicial;
        private System.Windows.Forms.Label lbl_tipo_cuenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView data_cuenta;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.TextBox box_saldo;
        private System.Windows.Forms.TextBox box_find_cuenta;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_bloquear;
        private System.Windows.Forms.Label lbl_estado_cuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_fcuentas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView view_fcuentas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox box_codigo_fcuentas;
        private System.Windows.Forms.Button btn_desbloquear;
    }
}