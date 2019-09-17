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
            // 
            // btnCRUDAgencias
            // 
            this.btnCRUDAgencias.Location = new System.Drawing.Point(122, 81);
            this.btnCRUDAgencias.Name = "btnCRUDAgencias";
            this.btnCRUDAgencias.Size = new System.Drawing.Size(161, 23);
            this.btnCRUDAgencias.TabIndex = 2;
            this.btnCRUDAgencias.Text = "ABC DE Agencias";
            this.btnCRUDAgencias.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(122, 122);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(161, 23);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.button4_Click);
            // 
            // MenuMantenimientoDBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnCRUDAgencias);
            this.Controls.Add(this.btnCRUDUsuarios);
            this.Controls.Add(this.btnCRUDBancos);
            this.Name = "MenuMantenimientoDBA";
            this.Text = "MenuMantenimientoDBA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCRUDBancos;
        private System.Windows.Forms.Button btnCRUDUsuarios;
        private System.Windows.Forms.Button btnCRUDAgencias;
        private System.Windows.Forms.Button btnRegresar;
    }
}