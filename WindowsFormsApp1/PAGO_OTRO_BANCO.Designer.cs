namespace WindowsFormsApp1
{
    partial class PAGO_OTRO_BANCO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_envcompens = new System.Windows.Forms.Button();
            this.txtnocuenta = new System.Windows.Forms.TextBox();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.txtnocheque = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.combo_bank = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.btn_cobrar = new System.Windows.Forms.Button();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_nocheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gen_comp = new System.Windows.Forms.TabPage();
            this.combo_makebank = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bnt_generar = new System.Windows.Forms.Button();
            this.upload_conciliados = new System.Windows.Forms.TabPage();
            this.btn_conciliado = new System.Windows.Forms.Button();
            this.btn_conciliar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gen_comp.SuspendLayout();
            this.upload_conciliados.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "No. Cheque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Banco";
            // 
            // btn_envcompens
            // 
            this.btn_envcompens.Location = new System.Drawing.Point(138, 287);
            this.btn_envcompens.Name = "btn_envcompens";
            this.btn_envcompens.Size = new System.Drawing.Size(142, 75);
            this.btn_envcompens.TabIndex = 4;
            this.btn_envcompens.Text = "Enviar a\r\nCompensación";
            this.btn_envcompens.UseVisualStyleBackColor = true;
            this.btn_envcompens.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtnocuenta
            // 
            this.txtnocuenta.Location = new System.Drawing.Point(173, 39);
            this.txtnocuenta.Name = "txtnocuenta";
            this.txtnocuenta.Size = new System.Drawing.Size(151, 22);
            this.txtnocuenta.TabIndex = 5;
            this.txtnocuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entero_KeyPress);
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(173, 97);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(151, 22);
            this.txtmonto.TabIndex = 6;
            this.txtmonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.decimal_KeyPress);
            // 
            // txtnocheque
            // 
            this.txtnocheque.Location = new System.Drawing.Point(173, 153);
            this.txtnocheque.Name = "txtnocheque";
            this.txtnocheque.Size = new System.Drawing.Size(151, 22);
            this.txtnocheque.TabIndex = 7;
            this.txtnocheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entero_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.gen_comp);
            this.tabControl1.Controls.Add(this.upload_conciliados);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(43, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 642);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.combo_bank);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtnocheque);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtmonto);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtnocuenta);
            this.tabPage1.Controls.Add(this.btn_envcompens);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cobro de cheque";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // combo_bank
            // 
            this.combo_bank.FormattingEnabled = true;
            this.combo_bank.Location = new System.Drawing.Point(173, 201);
            this.combo_bank.Name = "combo_bank";
            this.combo_bank.Size = new System.Drawing.Size(151, 24);
            this.combo_bank.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_descripcion);
            this.tabPage2.Controls.Add(this.btn_cobrar);
            this.tabPage2.Controls.Add(this.lbl_nombre);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btn_buscar);
            this.tabPage2.Controls.Add(this.txt_nocheque);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta cheque";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Location = new System.Drawing.Point(149, 247);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(46, 17);
            this.lbl_descripcion.TabIndex = 6;
            this.lbl_descripcion.Text = "label7";
            // 
            // btn_cobrar
            // 
            this.btn_cobrar.Enabled = false;
            this.btn_cobrar.Location = new System.Drawing.Point(59, 280);
            this.btn_cobrar.Name = "btn_cobrar";
            this.btn_cobrar.Size = new System.Drawing.Size(113, 46);
            this.btn_cobrar.TabIndex = 5;
            this.btn_cobrar.Text = "Cobrar";
            this.btn_cobrar.UseVisualStyleBackColor = true;
            this.btn_cobrar.Click += new System.EventHandler(this.btn_cobrar_Click);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(149, 214);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(46, 17);
            this.lbl_nombre.TabIndex = 4;
            this.lbl_nombre.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Estado:";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(59, 111);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(113, 46);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_nocheque
            // 
            this.txt_nocheque.Location = new System.Drawing.Point(189, 57);
            this.txt_nocheque.Name = "txt_nocheque";
            this.txt_nocheque.Size = new System.Drawing.Size(149, 22);
            this.txt_nocheque.TabIndex = 1;
            this.txt_nocheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entero_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "No. Cheque";
            // 
            // gen_comp
            // 
            this.gen_comp.Controls.Add(this.dataGridView2);
            this.gen_comp.Controls.Add(this.combo_makebank);
            this.gen_comp.Controls.Add(this.label7);
            this.gen_comp.Controls.Add(this.bnt_generar);
            this.gen_comp.Location = new System.Drawing.Point(4, 25);
            this.gen_comp.Name = "gen_comp";
            this.gen_comp.Padding = new System.Windows.Forms.Padding(3);
            this.gen_comp.Size = new System.Drawing.Size(934, 613);
            this.gen_comp.TabIndex = 2;
            this.gen_comp.Text = "Genera Archivo";
            this.gen_comp.UseVisualStyleBackColor = true;
            // 
            // combo_makebank
            // 
            this.combo_makebank.FormattingEnabled = true;
            this.combo_makebank.Location = new System.Drawing.Point(382, 137);
            this.combo_makebank.Name = "combo_makebank";
            this.combo_makebank.Size = new System.Drawing.Size(213, 24);
            this.combo_makebank.TabIndex = 2;
            this.combo_makebank.SelectedIndexChanged += new System.EventHandler(this.combo_makebank_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(340, 68);
            this.label7.TabIndex = 1;
            this.label7.Text = "A continuacion se presenta la opcion para generar \r\nel archivo de compensaciones " +
    "con el formato y sera \r\ndevuelto en un archivo txt para poderse compartir \r\ncon " +
    "los otros grupos";
            // 
            // bnt_generar
            // 
            this.bnt_generar.Location = new System.Drawing.Point(429, 492);
            this.bnt_generar.Name = "bnt_generar";
            this.bnt_generar.Size = new System.Drawing.Size(147, 91);
            this.bnt_generar.TabIndex = 0;
            this.bnt_generar.Text = "Generar Archivo";
            this.bnt_generar.UseVisualStyleBackColor = true;
            this.bnt_generar.Click += new System.EventHandler(this.bnt_generar_Click);
            // 
            // upload_conciliados
            // 
            this.upload_conciliados.Controls.Add(this.btn_conciliado);
            this.upload_conciliados.Controls.Add(this.btn_conciliar);
            this.upload_conciliados.Controls.Add(this.label9);
            this.upload_conciliados.Controls.Add(this.label8);
            this.upload_conciliados.Location = new System.Drawing.Point(4, 25);
            this.upload_conciliados.Name = "upload_conciliados";
            this.upload_conciliados.Padding = new System.Windows.Forms.Padding(3);
            this.upload_conciliados.Size = new System.Drawing.Size(934, 613);
            this.upload_conciliados.TabIndex = 3;
            this.upload_conciliados.Text = "Cargar Conciliados";
            this.upload_conciliados.UseVisualStyleBackColor = true;
            // 
            // btn_conciliado
            // 
            this.btn_conciliado.Location = new System.Drawing.Point(139, 326);
            this.btn_conciliado.Name = "btn_conciliado";
            this.btn_conciliado.Size = new System.Drawing.Size(128, 61);
            this.btn_conciliado.TabIndex = 3;
            this.btn_conciliado.Text = "Cargar archivo para conciliar";
            this.btn_conciliado.UseVisualStyleBackColor = true;
            this.btn_conciliado.Click += new System.EventHandler(this.btn_conciliado_Click);
            // 
            // btn_conciliar
            // 
            this.btn_conciliar.Location = new System.Drawing.Point(139, 115);
            this.btn_conciliar.Name = "btn_conciliar";
            this.btn_conciliar.Size = new System.Drawing.Size(128, 61);
            this.btn_conciliar.TabIndex = 2;
            this.btn_conciliar.Text = "Cargar archivo generados de la conciliacion";
            this.btn_conciliar.UseVisualStyleBackColor = true;
            this.btn_conciliar.Click += new System.EventHandler(this.btn_conciliar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 51);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cargar archivo que generaron \r\notros grupos para lleva a cabo\r\nla conciliacion po" +
    "r mi banco";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 51);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cargar archivo que generaron \r\notros grupos como resultado\r\nde la conciliacion";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(934, 613);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Liberacion Reserva";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 516);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 72);
            this.button2.TabIndex = 3;
            this.button2.Text = "Liberar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(874, 159);
            this.dataGridView1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "En Reserva";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(66, 211);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(807, 215);
            this.dataGridView2.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Aprobados";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 295);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Rechazados";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(33, 315);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(874, 178);
            this.dataGridView3.TabIndex = 6;
            // 
            // PAGO_OTRO_BANCO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 739);
            this.Controls.Add(this.tabControl1);
            this.Name = "PAGO_OTRO_BANCO";
            this.Text = "PAGO_OTRO_BANCO";
            this.Load += new System.EventHandler(this.PAGO_OTRO_BANCO_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gen_comp.ResumeLayout(false);
            this.gen_comp.PerformLayout();
            this.upload_conciliados.ResumeLayout(false);
            this.upload_conciliados.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_envcompens;
        private System.Windows.Forms.TextBox txtnocuenta;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.TextBox txtnocheque;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_cobrar;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_nocheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_bank;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.TabPage gen_comp;
        private System.Windows.Forms.ComboBox combo_makebank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bnt_generar;
        private System.Windows.Forms.TabPage upload_conciliados;
        private System.Windows.Forms.Button btn_conciliado;
        private System.Windows.Forms.Button btn_conciliar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}