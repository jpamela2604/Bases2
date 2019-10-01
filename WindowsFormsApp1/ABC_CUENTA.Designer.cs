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
            this.btn_crear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flow_cuentas = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_tipo_cuenta = new System.Windows.Forms.Label();
            this.lbl_saldo_inicial = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.data_cuenta = new System.Windows.Forms.DataGridView();
            this.box_saldo = new System.Windows.Forms.TextBox();
            this.box_find_cuenta = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_cuenta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 597);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 568);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CREAR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_crear
            // 
            this.btn_crear.Location = new System.Drawing.Point(566, 456);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(106, 47);
            this.btn_crear.TabIndex = 7;
            this.btn_crear.Text = "Aceptar";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flow_cuentas
            // 
            this.flow_cuentas.AutoScroll = true;
            this.flow_cuentas.Location = new System.Drawing.Point(202, 173);
            this.flow_cuentas.Name = "flow_cuentas";
            this.flow_cuentas.Size = new System.Drawing.Size(328, 184);
            this.flow_cuentas.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero(s) de cuenta";
            this.toolTip1.SetToolTip(this.label2, "Debe ingresar el numero de cliente al cual le pertenecerá la cuenta\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(57, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo inicial";
            this.toolTip1.SetToolTip(this.label1, "Debe ingresar un saldo para aperturar la cuenta");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.box_find_cuenta);
            this.tabPage2.Controls.Add(this.data_cuenta);
            this.tabPage2.Controls.Add(this.lbl_saldo_inicial);
            this.tabPage2.Controls.Add(this.lbl_tipo_cuenta);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_buscar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MODIFICAR";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingrese numero de cuenta";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(534, 45);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Cuenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saldo inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cuenta Habientes";
            // 
            // lbl_tipo_cuenta
            // 
            this.lbl_tipo_cuenta.AutoSize = true;
            this.lbl_tipo_cuenta.Location = new System.Drawing.Point(300, 128);
            this.lbl_tipo_cuenta.Name = "lbl_tipo_cuenta";
            this.lbl_tipo_cuenta.Size = new System.Drawing.Size(63, 17);
            this.lbl_tipo_cuenta.TabIndex = 9;
            this.lbl_tipo_cuenta.Text = "-----------";
            // 
            // lbl_saldo_inicial
            // 
            this.lbl_saldo_inicial.AutoSize = true;
            this.lbl_saldo_inicial.Location = new System.Drawing.Point(303, 178);
            this.lbl_saldo_inicial.Name = "lbl_saldo_inicial";
            this.lbl_saldo_inicial.Size = new System.Drawing.Size(63, 17);
            this.lbl_saldo_inicial.TabIndex = 10;
            this.lbl_saldo_inicial.Text = "-----------";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // data_cuenta
            // 
            this.data_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_cuenta.Location = new System.Drawing.Point(300, 239);
            this.data_cuenta.Name = "data_cuenta";
            this.data_cuenta.RowTemplate.Height = 24;
            this.data_cuenta.Size = new System.Drawing.Size(309, 211);
            this.data_cuenta.TabIndex = 11;
            // 
            // box_saldo
            // 
            this.box_saldo.Location = new System.Drawing.Point(202, 56);
            this.box_saldo.Name = "box_saldo";
            this.box_saldo.Size = new System.Drawing.Size(174, 22);
            this.box_saldo.TabIndex = 8;
            this.box_saldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // box_find_cuenta
            // 
            this.box_find_cuenta.Location = new System.Drawing.Point(303, 45);
            this.box_find_cuenta.Name = "box_find_cuenta";
            this.box_find_cuenta.Size = new System.Drawing.Size(153, 22);
            this.box_find_cuenta.TabIndex = 12;
            this.box_find_cuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // ABC_CUENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 619);
            this.Controls.Add(this.tabControl1);
            this.Name = "ABC_CUENTA";
            this.Text = "ABC_CUENTA";
            this.Load += new System.EventHandler(this.ABC_CUENTA_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_cuenta)).EndInit();
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
    }
}