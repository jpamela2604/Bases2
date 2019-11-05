namespace WindowsFormsApp1
{
    partial class PAGO_CHEQUE
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
            this.txt_nocuenta = new System.Windows.Forms.TextBox();
            this.txt_nocheque = new System.Windows.Forms.TextBox();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.btn_verif = new System.Windows.Forms.Button();
            this.btn_cobrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pic_firma = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "No. cheque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_nocuenta
            // 
            this.txt_nocuenta.Location = new System.Drawing.Point(204, 71);
            this.txt_nocuenta.MaxLength = 4;
            this.txt_nocuenta.Name = "txt_nocuenta";
            this.txt_nocuenta.Size = new System.Drawing.Size(165, 22);
            this.txt_nocuenta.TabIndex = 3;
            this.txt_nocuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entero_KeyPress);
            // 
            // txt_nocheque
            // 
            this.txt_nocheque.Location = new System.Drawing.Point(204, 137);
            this.txt_nocheque.MaxLength = 4;
            this.txt_nocheque.Name = "txt_nocheque";
            this.txt_nocheque.Size = new System.Drawing.Size(165, 22);
            this.txt_nocheque.TabIndex = 4;
            this.txt_nocheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entero_KeyPress);
            // 
            // txt_monto
            // 
            this.txt_monto.Location = new System.Drawing.Point(204, 206);
            this.txt_monto.MaxLength = 7;
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(165, 22);
            this.txt_monto.TabIndex = 5;
            this.txt_monto.TextChanged += new System.EventHandler(this.txt_monto_TextChanged);
            this.txt_monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.decimal_KeyPress);
            // 
            // btn_verif
            // 
            this.btn_verif.Location = new System.Drawing.Point(452, 51);
            this.btn_verif.Name = "btn_verif";
            this.btn_verif.Size = new System.Drawing.Size(137, 57);
            this.btn_verif.TabIndex = 6;
            this.btn_verif.Text = "VERIFICAR";
            this.btn_verif.UseVisualStyleBackColor = true;
            this.btn_verif.Click += new System.EventHandler(this.btn_verif_Click);
            // 
            // btn_cobrar
            // 
            this.btn_cobrar.Location = new System.Drawing.Point(92, 299);
            this.btn_cobrar.Name = "btn_cobrar";
            this.btn_cobrar.Size = new System.Drawing.Size(137, 57);
            this.btn_cobrar.TabIndex = 7;
            this.btn_cobrar.Text = "COBRAR";
            this.btn_cobrar.UseVisualStyleBackColor = true;
            this.btn_cobrar.Click += new System.EventHandler(this.btn_cobrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Firma:";
            // 
            // pic_firma
            // 
            this.pic_firma.Location = new System.Drawing.Point(653, 107);
            this.pic_firma.Name = "pic_firma";
            this.pic_firma.Size = new System.Drawing.Size(205, 151);
            this.pic_firma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_firma.TabIndex = 9;
            this.pic_firma.TabStop = false;
            // 
            // PAGO_CHEQUE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 389);
            this.Controls.Add(this.pic_firma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_cobrar);
            this.Controls.Add(this.btn_verif);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.txt_nocheque);
            this.Controls.Add(this.txt_nocuenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PAGO_CHEQUE";
            this.Text = "PAGO_CHEQUE";
            this.Load += new System.EventHandler(this.PAGO_CHEQUE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nocuenta;
        private System.Windows.Forms.TextBox txt_nocheque;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.Button btn_verif;
        private System.Windows.Forms.Button btn_cobrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic_firma;
    }
}