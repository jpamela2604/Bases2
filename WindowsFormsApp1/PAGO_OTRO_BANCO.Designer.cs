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
            this.btn_cobrar = new System.Windows.Forms.Button();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_nocheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.gen_comp = new System.Windows.Forms.TabPage();
            this.bnt_generar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_makebank = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gen_comp.SuspendLayout();
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
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(173, 97);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(151, 22);
            this.txtmonto.TabIndex = 6;
            // 
            // txtnocheque
            // 
            this.txtnocheque.Location = new System.Drawing.Point(173, 153);
            this.txtnocheque.Name = "txtnocheque";
            this.txtnocheque.Size = new System.Drawing.Size(151, 22);
            this.txtnocheque.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.gen_comp);
            this.tabControl1.Location = new System.Drawing.Point(43, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 444);
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
            // btn_cobrar
            // 
            this.btn_cobrar.Enabled = false;
            this.btn_cobrar.Location = new System.Drawing.Point(59, 280);
            this.btn_cobrar.Name = "btn_cobrar";
            this.btn_cobrar.Size = new System.Drawing.Size(113, 46);
            this.btn_cobrar.TabIndex = 5;
            this.btn_cobrar.Text = "Cobrar";
            this.btn_cobrar.UseVisualStyleBackColor = true;
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
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Location = new System.Drawing.Point(149, 247);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(46, 17);
            this.lbl_descripcion.TabIndex = 6;
            this.lbl_descripcion.Text = "label7";
            // 
            // gen_comp
            // 
            this.gen_comp.Controls.Add(this.combo_makebank);
            this.gen_comp.Controls.Add(this.label7);
            this.gen_comp.Controls.Add(this.bnt_generar);
            this.gen_comp.Location = new System.Drawing.Point(4, 25);
            this.gen_comp.Name = "gen_comp";
            this.gen_comp.Padding = new System.Windows.Forms.Padding(3);
            this.gen_comp.Size = new System.Drawing.Size(399, 415);
            this.gen_comp.TabIndex = 2;
            this.gen_comp.Text = "Genera Archivo";
            this.gen_comp.UseVisualStyleBackColor = true;
            // 
            // bnt_generar
            // 
            this.bnt_generar.Location = new System.Drawing.Point(128, 255);
            this.bnt_generar.Name = "bnt_generar";
            this.bnt_generar.Size = new System.Drawing.Size(147, 91);
            this.bnt_generar.TabIndex = 0;
            this.bnt_generar.Text = "Generar Archivo";
            this.bnt_generar.UseVisualStyleBackColor = true;
            this.bnt_generar.Click += new System.EventHandler(this.bnt_generar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(340, 68);
            this.label7.TabIndex = 1;
            this.label7.Text = "A continuacion se presenta la opcion para generar \r\nel archivo de compensaciones " +
    "con el formato y sera \r\ndevuelto en un archivo txt para poderse compartir \r\ncon " +
    "los otros grupos";
            // 
            // combo_makebank
            // 
            this.combo_makebank.FormattingEnabled = true;
            this.combo_makebank.Location = new System.Drawing.Point(90, 154);
            this.combo_makebank.Name = "combo_makebank";
            this.combo_makebank.Size = new System.Drawing.Size(213, 24);
            this.combo_makebank.TabIndex = 2;
            // 
            // PAGO_OTRO_BANCO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 532);
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
    }
}