namespace WindowsFormsApp1
{
    partial class Deposito
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.txtnocuenta = new System.Windows.Forms.TextBox();
            this.combo_bank = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.externo = new System.Windows.Forms.Button();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.txtnocheque = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pic_firma = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.local = new System.Windows.Forms.Button();
            this.btn_verif = new System.Windows.Forms.Button();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.txt_nocheque = new System.Windows.Forms.TextBox();
            this.txt_nocuenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.monetario = new System.Windows.Forms.Button();
            this.Monto = new System.Windows.Forms.TextBox();
            this.NumeroCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "DEPOSITO";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.txtnocuenta);
            this.tabPage3.Controls.Add(this.combo_bank);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.externo);
            this.tabPage3.Controls.Add(this.txtmonto);
            this.tabPage3.Controls.Add(this.txtnocheque);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(560, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cheque Externo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 139);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "No. Cuenta";
            // 
            // txtnocuenta
            // 
            this.txtnocuenta.Location = new System.Drawing.Point(197, 139);
            this.txtnocuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtnocuenta.Name = "txtnocuenta";
            this.txtnocuenta.Size = new System.Drawing.Size(130, 20);
            this.txtnocuenta.TabIndex = 38;
            // 
            // combo_bank
            // 
            this.combo_bank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_bank.FormattingEnabled = true;
            this.combo_bank.Location = new System.Drawing.Point(197, 106);
            this.combo_bank.Name = "combo_bank";
            this.combo_bank.Size = new System.Drawing.Size(130, 21);
            this.combo_bank.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Banco de Procedencia:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(246, 20);
            this.textBox2.TabIndex = 34;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Número de Cuenta que Recibe: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Informacion del cheque:";
            // 
            // externo
            // 
            this.externo.Location = new System.Drawing.Point(395, 207);
            this.externo.Margin = new System.Windows.Forms.Padding(2);
            this.externo.Name = "externo";
            this.externo.Size = new System.Drawing.Size(103, 46);
            this.externo.TabIndex = 30;
            this.externo.Text = "DEPOSITAR";
            this.externo.UseVisualStyleBackColor = true;
            this.externo.Click += new System.EventHandler(this.externo_Click);
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(197, 204);
            this.txtmonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtmonto.MaxLength = 7;
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(130, 20);
            this.txtmonto.TabIndex = 28;
            this.txtmonto.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtnocheque
            // 
            this.txtnocheque.Location = new System.Drawing.Point(197, 171);
            this.txtnocheque.Margin = new System.Windows.Forms.Padding(2);
            this.txtnocheque.MaxLength = 4;
            this.txtnocheque.Name = "txtnocheque";
            this.txtnocheque.Size = new System.Drawing.Size(130, 20);
            this.txtnocheque.TabIndex = 27;
            this.txtnocheque.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 207);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Monto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 171);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "No. cheque";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.pic_firma);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.local);
            this.tabPage2.Controls.Add(this.btn_verif);
            this.tabPage2.Controls.Add(this.txt_monto);
            this.tabPage2.Controls.Add(this.txt_nocheque);
            this.tabPage2.Controls.Add(this.txt_nocuenta);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cheque Local";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Número de Cuenta que Recibe: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Informacion del cheque:";
            // 
            // pic_firma
            // 
            this.pic_firma.Location = new System.Drawing.Point(378, 101);
            this.pic_firma.Margin = new System.Windows.Forms.Padding(2);
            this.pic_firma.Name = "pic_firma";
            this.pic_firma.Size = new System.Drawing.Size(154, 123);
            this.pic_firma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_firma.TabIndex = 19;
            this.pic_firma.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, -18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Firma:";
            // 
            // local
            // 
            this.local.Location = new System.Drawing.Point(104, 220);
            this.local.Margin = new System.Windows.Forms.Padding(2);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(103, 46);
            this.local.TabIndex = 17;
            this.local.Text = "DEPOSITAR";
            this.local.UseVisualStyleBackColor = true;
            this.local.Click += new System.EventHandler(this.local_Click);
            // 
            // btn_verif
            // 
            this.btn_verif.Location = new System.Drawing.Point(253, 99);
            this.btn_verif.Margin = new System.Windows.Forms.Padding(2);
            this.btn_verif.Name = "btn_verif";
            this.btn_verif.Size = new System.Drawing.Size(103, 46);
            this.btn_verif.TabIndex = 16;
            this.btn_verif.Text = "VERIFICAR";
            this.btn_verif.UseVisualStyleBackColor = true;
            this.btn_verif.Click += new System.EventHandler(this.btn_verif_Click);
            // 
            // txt_monto
            // 
            this.txt_monto.Location = new System.Drawing.Point(104, 164);
            this.txt_monto.Margin = new System.Windows.Forms.Padding(2);
            this.txt_monto.MaxLength = 7;
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(125, 20);
            this.txt_monto.TabIndex = 15;
            this.txt_monto.TextChanged += new System.EventHandler(this.txt_monto_TextChanged);
            // 
            // txt_nocheque
            // 
            this.txt_nocheque.Location = new System.Drawing.Point(104, 132);
            this.txt_nocheque.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nocheque.MaxLength = 4;
            this.txt_nocheque.Name = "txt_nocheque";
            this.txt_nocheque.Size = new System.Drawing.Size(125, 20);
            this.txt_nocheque.TabIndex = 14;
            this.txt_nocheque.TextChanged += new System.EventHandler(this.txt_nocheque_TextChanged);
            // 
            // txt_nocuenta
            // 
            this.txt_nocuenta.Location = new System.Drawing.Point(104, 101);
            this.txt_nocuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nocuenta.MaxLength = 4;
            this.txt_nocuenta.Name = "txt_nocuenta";
            this.txt_nocuenta.Size = new System.Drawing.Size(125, 20);
            this.txt_nocuenta.TabIndex = 13;
            this.txt_nocuenta.TextChanged += new System.EventHandler(this.txt_nocuenta_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Monto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "No. cheque";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "No. Cuenta";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.monetario);
            this.tabPage1.Controls.Add(this.Monto);
            this.tabPage1.Controls.Add(this.NumeroCuenta);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Efectivo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // monetario
            // 
            this.monetario.Location = new System.Drawing.Point(216, 143);
            this.monetario.Name = "monetario";
            this.monetario.Size = new System.Drawing.Size(122, 40);
            this.monetario.TabIndex = 13;
            this.monetario.Text = "Hacer Deposito";
            this.monetario.UseVisualStyleBackColor = true;
            this.monetario.Click += new System.EventHandler(this.monetario_Click);
            // 
            // Monto
            // 
            this.Monto.Location = new System.Drawing.Point(216, 83);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(100, 20);
            this.Monto.TabIndex = 12;
            this.Monto.TextChanged += new System.EventHandler(this.Monto_TextChanged);
            // 
            // NumeroCuenta
            // 
            this.NumeroCuenta.Location = new System.Drawing.Point(216, 54);
            this.NumeroCuenta.Name = "NumeroCuenta";
            this.NumeroCuenta.Size = new System.Drawing.Size(246, 20);
            this.NumeroCuenta.TabIndex = 10;
            this.NumeroCuenta.TextChanged += new System.EventHandler(this.NumeroCuenta_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Número de Cuenta: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(27, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 313);
            this.tabControl1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(498, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Cerrar Sesión";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Deposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 379);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Deposito";
            this.Text = "Deposito";
            this.Load += new System.EventHandler(this.Deposito_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button monetario;
        private System.Windows.Forms.TextBox Monto;
        private System.Windows.Forms.TextBox NumeroCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pic_firma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button local;
        private System.Windows.Forms.Button btn_verif;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.TextBox txt_nocheque;
        private System.Windows.Forms.TextBox txt_nocuenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_bank;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button externo;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.TextBox txtnocheque;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtnocuenta;
    }
}