namespace WindowsFormsApp1
{
    partial class MenuMantenimientoDBA
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
            this.btnCRUDBancos = new System.Windows.Forms.Button();
            this.btnCRUDUsuarios = new System.Windows.Forms.Button();
            this.btnCRUDAgencias = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCRUDBancos
            // 
            this.btnCRUDBancos.Location = new System.Drawing.Point(122, 22);
            this.btnCRUDBancos.Name = "btnCRUDBancos";
            this.btnCRUDBancos.Size = new System.Drawing.Size(161, 23);
            this.btnCRUDBancos.TabIndex = 0;
            this.btnCRUDBancos.Text = "ABC de Bancos";
            this.btnCRUDBancos.UseVisualStyleBackColor = true;
            this.btnCRUDBancos.Click += new System.EventHandler(this.btnCRUDBancos_Click);
            // 
            // btnCRUDUsuarios
            // 
            this.btnCRUDUsuarios.Location = new System.Drawing.Point(122, 52);
            this.btnCRUDUsuarios.Name = "btnCRUDUsuarios";
            this.btnCRUDUsuarios.Size = new System.Drawing.Size(161, 23);
            this.btnCRUDUsuarios.TabIndex = 1;
            this.btnCRUDUsuarios.Text = "ABC de Usuarios";
            this.btnCRUDUsuarios.UseVisualStyleBackColor = true;
            this.btnCRUDUsuarios.Click += new System.EventHandler(this.btnCRUDUsuarios_Click);
            // 
            // btnCRUDAgencias
            // 
            this.btnCRUDAgencias.Location = new System.Drawing.Point(122, 81);
            this.btnCRUDAgencias.Name = "btnCRUDAgencias";
            this.btnCRUDAgencias.Size = new System.Drawing.Size(161, 23);
            this.btnCRUDAgencias.TabIndex = 2;
            this.btnCRUDAgencias.Text = "ABC de Agencias";
            this.btnCRUDAgencias.UseVisualStyleBackColor = true;
            this.btnCRUDAgencias.Click += new System.EventHandler(this.btnCRUDAgencias_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(122, 330);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(161, 23);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "ABC de Equipos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "ROLES";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(122, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Funciones";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(122, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Asignacion de Rol";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MenuMantenimientoDBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 409);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnCRUDAgencias);
            this.Controls.Add(this.btnCRUDUsuarios);
            this.Controls.Add(this.btnCRUDBancos);
            this.Name = "MenuMantenimientoDBA";
            this.Text = "MenuMantenimientoDBA";
            this.Load += new System.EventHandler(this.MenuMantenimientoDBA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCRUDBancos;
        private System.Windows.Forms.Button btnCRUDUsuarios;
        private System.Windows.Forms.Button btnCRUDAgencias;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}