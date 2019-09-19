namespace WindowsFormsApp1
{
    partial class ABC_CLIENTE
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
            this.tab_cliente = new System.Windows.Forms.TabControl();
            this.add_cliente = new System.Windows.Forms.TabPage();
            this.but_enviar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pic_firma = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.box_firma = new System.Windows.Forms.TextBox();
            this.box_foto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.box_correo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.box_telefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.box_nit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.box_direccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_nombre = new System.Windows.Forms.TextBox();
            this.pic_foto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_tipo = new System.Windows.Forms.ComboBox();
            this.get_cliente = new System.Windows.Forms.TabPage();
            this.remove_cliente = new System.Windows.Forms.TabPage();
            this.modif_cliente = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.box_dpi = new System.Windows.Forms.TextBox();
            this.tab_cliente.SuspendLayout();
            this.add_cliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_cliente
            // 
            this.tab_cliente.Controls.Add(this.add_cliente);
            this.tab_cliente.Controls.Add(this.get_cliente);
            this.tab_cliente.Controls.Add(this.remove_cliente);
            this.tab_cliente.Controls.Add(this.modif_cliente);
            this.tab_cliente.Location = new System.Drawing.Point(64, 30);
            this.tab_cliente.Name = "tab_cliente";
            this.tab_cliente.SelectedIndex = 0;
            this.tab_cliente.Size = new System.Drawing.Size(913, 518);
            this.tab_cliente.TabIndex = 0;
            // 
            // add_cliente
            // 
            this.add_cliente.Controls.Add(this.label11);
            this.add_cliente.Controls.Add(this.box_dpi);
            this.add_cliente.Controls.Add(this.but_enviar);
            this.add_cliente.Controls.Add(this.label10);
            this.add_cliente.Controls.Add(this.label9);
            this.add_cliente.Controls.Add(this.pic_firma);
            this.add_cliente.Controls.Add(this.button2);
            this.add_cliente.Controls.Add(this.button1);
            this.add_cliente.Controls.Add(this.box_firma);
            this.add_cliente.Controls.Add(this.box_foto);
            this.add_cliente.Controls.Add(this.label8);
            this.add_cliente.Controls.Add(this.label7);
            this.add_cliente.Controls.Add(this.label6);
            this.add_cliente.Controls.Add(this.box_correo);
            this.add_cliente.Controls.Add(this.label5);
            this.add_cliente.Controls.Add(this.box_telefono);
            this.add_cliente.Controls.Add(this.label4);
            this.add_cliente.Controls.Add(this.box_nit);
            this.add_cliente.Controls.Add(this.label3);
            this.add_cliente.Controls.Add(this.box_direccion);
            this.add_cliente.Controls.Add(this.label2);
            this.add_cliente.Controls.Add(this.box_nombre);
            this.add_cliente.Controls.Add(this.pic_foto);
            this.add_cliente.Controls.Add(this.label1);
            this.add_cliente.Controls.Add(this.combo_tipo);
            this.add_cliente.Location = new System.Drawing.Point(4, 25);
            this.add_cliente.Name = "add_cliente";
            this.add_cliente.Padding = new System.Windows.Forms.Padding(3);
            this.add_cliente.Size = new System.Drawing.Size(905, 489);
            this.add_cliente.TabIndex = 1;
            this.add_cliente.Text = "Agregar Cliente";
            this.add_cliente.UseVisualStyleBackColor = true;
            // 
            // but_enviar
            // 
            this.but_enviar.Location = new System.Drawing.Point(253, 439);
            this.but_enviar.Name = "but_enviar";
            this.but_enviar.Size = new System.Drawing.Size(122, 34);
            this.but_enviar.TabIndex = 22;
            this.but_enviar.Text = "Enviar";
            this.but_enviar.UseVisualStyleBackColor = true;
            this.but_enviar.Click += new System.EventHandler(this.but_enviar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(646, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Firma";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(646, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Foto";
            // 
            // pic_firma
            // 
            this.pic_firma.Location = new System.Drawing.Point(697, 272);
            this.pic_firma.Name = "pic_firma";
            this.pic_firma.Size = new System.Drawing.Size(148, 178);
            this.pic_firma.TabIndex = 19;
            this.pic_firma.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // box_firma
            // 
            this.box_firma.Enabled = false;
            this.box_firma.Location = new System.Drawing.Point(203, 398);
            this.box_firma.Name = "box_firma";
            this.box_firma.Size = new System.Drawing.Size(212, 22);
            this.box_firma.TabIndex = 16;
            // 
            // box_foto
            // 
            this.box_foto.Enabled = false;
            this.box_foto.Location = new System.Drawing.Point(203, 354);
            this.box_foto.Name = "box_foto";
            this.box_foto.Size = new System.Drawing.Size(212, 22);
            this.box_foto.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Firma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Foto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Correo";
            // 
            // box_correo
            // 
            this.box_correo.Location = new System.Drawing.Point(203, 249);
            this.box_correo.Name = "box_correo";
            this.box_correo.Size = new System.Drawing.Size(212, 22);
            this.box_correo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telefono";
            // 
            // box_telefono
            // 
            this.box_telefono.Location = new System.Drawing.Point(203, 196);
            this.box_telefono.MaxLength = 8;
            this.box_telefono.Name = "box_telefono";
            this.box_telefono.Size = new System.Drawing.Size(212, 22);
            this.box_telefono.TabIndex = 9;
            this.box_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nit";
            // 
            // box_nit
            // 
            this.box_nit.Location = new System.Drawing.Point(203, 141);
            this.box_nit.Name = "box_nit";
            this.box_nit.Size = new System.Drawing.Size(212, 22);
            this.box_nit.TabIndex = 7;
            this.box_nit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Direccion";
            // 
            // box_direccion
            // 
            this.box_direccion.Location = new System.Drawing.Point(203, 101);
            this.box_direccion.MaxLength = 50;
            this.box_direccion.Name = "box_direccion";
            this.box_direccion.Size = new System.Drawing.Size(212, 22);
            this.box_direccion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // box_nombre
            // 
            this.box_nombre.Location = new System.Drawing.Point(203, 64);
            this.box_nombre.MaxLength = 50;
            this.box_nombre.Name = "box_nombre";
            this.box_nombre.Size = new System.Drawing.Size(212, 22);
            this.box_nombre.TabIndex = 3;
            // 
            // pic_foto
            // 
            this.pic_foto.Location = new System.Drawing.Point(697, 40);
            this.pic_foto.Name = "pic_foto";
            this.pic_foto.Size = new System.Drawing.Size(148, 178);
            this.pic_foto.TabIndex = 2;
            this.pic_foto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Cuenta";
            // 
            // combo_tipo
            // 
            this.combo_tipo.FormattingEnabled = true;
            this.combo_tipo.Location = new System.Drawing.Point(203, 303);
            this.combo_tipo.Name = "combo_tipo";
            this.combo_tipo.Size = new System.Drawing.Size(212, 24);
            this.combo_tipo.TabIndex = 0;
            // 
            // get_cliente
            // 
            this.get_cliente.Location = new System.Drawing.Point(4, 25);
            this.get_cliente.Name = "get_cliente";
            this.get_cliente.Padding = new System.Windows.Forms.Padding(3);
            this.get_cliente.Size = new System.Drawing.Size(905, 489);
            this.get_cliente.TabIndex = 2;
            this.get_cliente.Text = "Obtener Informacion ";
            this.get_cliente.UseVisualStyleBackColor = true;
            // 
            // remove_cliente
            // 
            this.remove_cliente.Location = new System.Drawing.Point(4, 25);
            this.remove_cliente.Name = "remove_cliente";
            this.remove_cliente.Padding = new System.Windows.Forms.Padding(3);
            this.remove_cliente.Size = new System.Drawing.Size(905, 489);
            this.remove_cliente.TabIndex = 3;
            this.remove_cliente.Text = "Eliminar Cliente";
            this.remove_cliente.UseVisualStyleBackColor = true;
            // 
            // modif_cliente
            // 
            this.modif_cliente.Location = new System.Drawing.Point(4, 25);
            this.modif_cliente.Name = "modif_cliente";
            this.modif_cliente.Padding = new System.Windows.Forms.Padding(3);
            this.modif_cliente.Size = new System.Drawing.Size(905, 489);
            this.modif_cliente.TabIndex = 4;
            this.modif_cliente.Text = "Modificar Cliente";
            this.modif_cliente.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "DPI";
            // 
            // box_dpi
            // 
            this.box_dpi.Location = new System.Drawing.Point(203, 32);
            this.box_dpi.MaxLength = 13;
            this.box_dpi.Name = "box_dpi";
            this.box_dpi.Size = new System.Drawing.Size(212, 22);
            this.box_dpi.TabIndex = 23;
            this.box_dpi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // ABC_CLIENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 582);
            this.Controls.Add(this.tab_cliente);
            this.Name = "ABC_CLIENTE";
            this.Text = "ABC_CLIENTE";
            this.Load += new System.EventHandler(this.ABC_CLIENTE_Load);
            this.tab_cliente.ResumeLayout(false);
            this.add_cliente.ResumeLayout(false);
            this.add_cliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_foto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_cliente;
        private System.Windows.Forms.TabPage add_cliente;
        private System.Windows.Forms.TabPage get_cliente;
        private System.Windows.Forms.TabPage remove_cliente;
        private System.Windows.Forms.TabPage modif_cliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox box_correo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox box_telefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox box_nit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox box_direccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox box_nombre;
        private System.Windows.Forms.PictureBox pic_foto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_tipo;
        private System.Windows.Forms.TextBox box_firma;
        private System.Windows.Forms.TextBox box_foto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pic_firma;
        private System.Windows.Forms.Button but_enviar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox box_dpi;
    }
}