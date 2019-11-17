namespace WindowsFormsApp1
{
    partial class NotaCredito
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
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crear = new System.Windows.Forms.Button();
            this.Monto = new System.Windows.Forms.TextBox();
            this.NumeroCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.consultar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOTA DE CREDITO";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(512, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Cerrar Sesión";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(58, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 248);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crear);
            this.tabPage1.Controls.Add(this.Monto);
            this.tabPage1.Controls.Add(this.NumeroCuenta);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(528, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Nota";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(200, 136);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(122, 40);
            this.crear.TabIndex = 18;
            this.crear.Text = "Crear";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.button1_Click);
            // 
            // Monto
            // 
            this.Monto.Location = new System.Drawing.Point(200, 76);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(100, 20);
            this.Monto.TabIndex = 17;
            this.Monto.TextChanged += new System.EventHandler(this.Monto_TextChanged);
            // 
            // NumeroCuenta
            // 
            this.NumeroCuenta.Location = new System.Drawing.Point(200, 47);
            this.NumeroCuenta.Name = "NumeroCuenta";
            this.NumeroCuenta.Size = new System.Drawing.Size(246, 20);
            this.NumeroCuenta.TabIndex = 15;
            this.NumeroCuenta.TextChanged += new System.EventHandler(this.NumeroCuenta_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Número de Cuenta: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.consultar);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar Nota";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // consultar
            // 
            this.consultar.Location = new System.Drawing.Point(380, 15);
            this.consultar.Name = "consultar";
            this.consultar.Size = new System.Drawing.Size(122, 40);
            this.consultar.TabIndex = 20;
            this.consultar.Text = "Consultar";
            this.consultar.UseVisualStyleBackColor = true;
            this.consultar.Click += new System.EventHandler(this.consultar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(246, 20);
            this.textBox2.TabIndex = 19;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Número de Cuenta: ";
            // 
            // NotaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 330);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Name = "NotaCredito";
            this.Text = "NotaCredito";
            this.Load += new System.EventHandler(this.NotaCredito_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.TextBox Monto;
        private System.Windows.Forms.TextBox NumeroCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button consultar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}