namespace WindowsFormsApp1
{
    partial class DepositoMonetario
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
            this.NumeroCuenta = new System.Windows.Forms.TextBox();
            this.tbTipoCheque = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Monto = new System.Windows.Forms.TextBox();
            this.checkEfectivo = new System.Windows.Forms.CheckBox();
            this.checkCheque = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumeroCheque = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deposito Monetario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de Cuenta: ";
            // 
            // NumeroCuenta
            // 
            this.NumeroCuenta.Location = new System.Drawing.Point(193, 97);
            this.NumeroCuenta.Name = "NumeroCuenta";
            this.NumeroCuenta.Size = new System.Drawing.Size(246, 20);
            this.NumeroCuenta.TabIndex = 2;
            this.NumeroCuenta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbTipoCheque
            // 
            this.tbTipoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbTipoCheque.FormattingEnabled = true;
            this.tbTipoCheque.Location = new System.Drawing.Point(207, 283);
            this.tbTipoCheque.Name = "tbTipoCheque";
            this.tbTipoCheque.Size = new System.Drawing.Size(121, 21);
            this.tbTipoCheque.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto:";
            // 
            // Monto
            // 
            this.Monto.Location = new System.Drawing.Point(193, 126);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(100, 20);
            this.Monto.TabIndex = 5;
            this.Monto.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkEfectivo
            // 
            this.checkEfectivo.AutoSize = true;
            this.checkEfectivo.Location = new System.Drawing.Point(92, 225);
            this.checkEfectivo.Name = "checkEfectivo";
            this.checkEfectivo.Size = new System.Drawing.Size(65, 17);
            this.checkEfectivo.TabIndex = 6;
            this.checkEfectivo.Text = "Efectivo";
            this.checkEfectivo.UseVisualStyleBackColor = true;
            this.checkEfectivo.CheckedChanged += new System.EventHandler(this.checkEfectivo_CheckedChanged);
            // 
            // checkCheque
            // 
            this.checkCheque.AutoSize = true;
            this.checkCheque.Location = new System.Drawing.Point(92, 248);
            this.checkCheque.Name = "checkCheque";
            this.checkCheque.Size = new System.Drawing.Size(63, 17);
            this.checkCheque.TabIndex = 7;
            this.checkCheque.Text = "Cheque";
            this.checkCheque.UseVisualStyleBackColor = true;
            this.checkCheque.CheckedChanged += new System.EventHandler(this.checkCheque_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Hacer Deposito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo Cheque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Número de Cheque:";
            // 
            // NumeroCheque
            // 
            this.NumeroCheque.Location = new System.Drawing.Point(207, 319);
            this.NumeroCheque.Name = "NumeroCheque";
            this.NumeroCheque.Size = new System.Drawing.Size(246, 20);
            this.NumeroCheque.TabIndex = 11;
            this.NumeroCheque.TextChanged += new System.EventHandler(this.tbNoCheque_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cerrar Sesión";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DepositoMonetario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 336);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NumeroCheque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkCheque);
            this.Controls.Add(this.checkEfectivo);
            this.Controls.Add(this.Monto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTipoCheque);
            this.Controls.Add(this.NumeroCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DepositoMonetario";
            this.Text = "DepositoMonetario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroCuenta;
        private System.Windows.Forms.ComboBox tbTipoCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Monto;
        private System.Windows.Forms.CheckBox checkEfectivo;
        private System.Windows.Forms.CheckBox checkCheque;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumeroCheque;
        private System.Windows.Forms.Button button2;
    }
}