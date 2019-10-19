namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMantenimientoDBA = new System.Windows.Forms.Button();
            this.btnNuevasCuentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMantenimientoDBA
            // 
            this.btnMantenimientoDBA.Location = new System.Drawing.Point(122, 56);
            this.btnMantenimientoDBA.Name = "btnMantenimientoDBA";
            this.btnMantenimientoDBA.Size = new System.Drawing.Size(90, 53);
            this.btnMantenimientoDBA.TabIndex = 0;
            this.btnMantenimientoDBA.Text = "Mantenimiento DBA";
            this.btnMantenimientoDBA.UseVisualStyleBackColor = true;
            this.btnMantenimientoDBA.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNuevasCuentas
            // 
            this.btnNuevasCuentas.Location = new System.Drawing.Point(298, 56);
            this.btnNuevasCuentas.Name = "btnNuevasCuentas";
            this.btnNuevasCuentas.Size = new System.Drawing.Size(75, 53);
            this.btnNuevasCuentas.TabIndex = 1;
            this.btnNuevasCuentas.Text = "Nuevas Cuentas";
            this.btnNuevasCuentas.UseVisualStyleBackColor = true;
            this.btnNuevasCuentas.Click += new System.EventHandler(this.btnNuevasCuentas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 160);
            this.Controls.Add(this.btnNuevasCuentas);
            this.Controls.Add(this.btnMantenimientoDBA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMantenimientoDBA;
        private System.Windows.Forms.Button btnNuevasCuentas;
    }
}

