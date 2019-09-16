namespace WindowsFormsApp1
{
    partial class MenuCuentasNuevas
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
            this.btnDatosCliente = new System.Windows.Forms.Button();
            this.btnAperturarCuenta = new System.Windows.Forms.Button();
            this.btnBloquearCuenta = new System.Windows.Forms.Button();
            this.btnSolicitarChequera = new System.Windows.Forms.Button();
            this.btnChequeExtraviado = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDatosCliente
            // 
            this.btnDatosCliente.Location = new System.Drawing.Point(64, 27);
            this.btnDatosCliente.Name = "btnDatosCliente";
            this.btnDatosCliente.Size = new System.Drawing.Size(294, 23);
            this.btnDatosCliente.TabIndex = 0;
            this.btnDatosCliente.Text = "ABC Datos Cliente";
            this.btnDatosCliente.UseVisualStyleBackColor = true;
            // 
            // btnAperturarCuenta
            // 
            this.btnAperturarCuenta.Location = new System.Drawing.Point(64, 70);
            this.btnAperturarCuenta.Name = "btnAperturarCuenta";
            this.btnAperturarCuenta.Size = new System.Drawing.Size(294, 23);
            this.btnAperturarCuenta.TabIndex = 1;
            this.btnAperturarCuenta.Text = "Apertura de una Cuenta";
            this.btnAperturarCuenta.UseVisualStyleBackColor = true;
            // 
            // btnBloquearCuenta
            // 
            this.btnBloquearCuenta.Location = new System.Drawing.Point(64, 114);
            this.btnBloquearCuenta.Name = "btnBloquearCuenta";
            this.btnBloquearCuenta.Size = new System.Drawing.Size(294, 23);
            this.btnBloquearCuenta.TabIndex = 2;
            this.btnBloquearCuenta.Text = "Cancelación/Bloqueo de Cuenta";
            this.btnBloquearCuenta.UseVisualStyleBackColor = true;
            // 
            // btnSolicitarChequera
            // 
            this.btnSolicitarChequera.Location = new System.Drawing.Point(64, 161);
            this.btnSolicitarChequera.Name = "btnSolicitarChequera";
            this.btnSolicitarChequera.Size = new System.Drawing.Size(294, 23);
            this.btnSolicitarChequera.TabIndex = 3;
            this.btnSolicitarChequera.Text = "Solicitud de chequera";
            this.btnSolicitarChequera.UseVisualStyleBackColor = true;
            // 
            // btnChequeExtraviado
            // 
            this.btnChequeExtraviado.Location = new System.Drawing.Point(64, 205);
            this.btnChequeExtraviado.Name = "btnChequeExtraviado";
            this.btnChequeExtraviado.Size = new System.Drawing.Size(294, 23);
            this.btnChequeExtraviado.TabIndex = 4;
            this.btnChequeExtraviado.Text = "Declaración de Cheque Robado/Extraviado";
            this.btnChequeExtraviado.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(64, 246);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(294, 23);
            this.btnRegresar.TabIndex = 5;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.button6_Click);
            // 
            // MenuCuentasNuevas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 296);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnChequeExtraviado);
            this.Controls.Add(this.btnSolicitarChequera);
            this.Controls.Add(this.btnBloquearCuenta);
            this.Controls.Add(this.btnAperturarCuenta);
            this.Controls.Add(this.btnDatosCliente);
            this.Name = "MenuCuentasNuevas";
            this.Text = "MenuCuentasNuevas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDatosCliente;
        private System.Windows.Forms.Button btnAperturarCuenta;
        private System.Windows.Forms.Button btnBloquearCuenta;
        private System.Windows.Forms.Button btnSolicitarChequera;
        private System.Windows.Forms.Button btnChequeExtraviado;
        private System.Windows.Forms.Button btnRegresar;
    }
}