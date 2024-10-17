namespace Gestión_de_Bibliotecas
{
    partial class FormPrestamos
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
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblLector = new System.Windows.Forms.Label();
            this.cbLibros = new System.Windows.Forms.ComboBox();
            this.cbLectores = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLibro
            // 
            this.lblLibro.AutoSize = true;
            this.lblLibro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibro.Location = new System.Drawing.Point(53, 49);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(55, 19);
            this.lblLibro.TabIndex = 0;
            this.lblLibro.Text = "Libro:";
            // 
            // lblLector
            // 
            this.lblLector.AutoSize = true;
            this.lblLector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLector.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLector.Location = new System.Drawing.Point(53, 98);
            this.lblLector.Name = "lblLector";
            this.lblLector.Size = new System.Drawing.Size(64, 19);
            this.lblLector.TabIndex = 1;
            this.lblLector.Text = "Lector:";
            // 
            // cbLibros
            // 
            this.cbLibros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbLibros.FormattingEnabled = true;
            this.cbLibros.Location = new System.Drawing.Point(111, 49);
            this.cbLibros.Name = "cbLibros";
            this.cbLibros.Size = new System.Drawing.Size(186, 21);
            this.cbLibros.TabIndex = 2;
            // 
            // cbLectores
            // 
            this.cbLectores.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cbLectores.FormattingEnabled = true;
            this.cbLectores.Location = new System.Drawing.Point(111, 98);
            this.cbLectores.Name = "cbLectores";
            this.cbLectores.Size = new System.Drawing.Size(186, 21);
            this.cbLectores.TabIndex = 3;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(303, 39);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(210, 37);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar Préstamo";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolver.Location = new System.Drawing.Point(303, 87);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(210, 37);
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Text = "Devolver Libro";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(56, 154);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.Size = new System.Drawing.Size(457, 195);
            this.dgvPrestamos.TabIndex = 6;
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.Honeydew;
            this.btnHistorial.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.Location = new System.Drawing.Point(56, 352);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(123, 35);
            this.btnHistorial.TabIndex = 7;
            this.btnHistorial.Text = "Ver Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(438, 123);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 30);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gestion de prestamo";
            // 
            // FormPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(596, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.cbLectores);
            this.Controls.Add(this.cbLibros);
            this.Controls.Add(this.lblLector);
            this.Controls.Add(this.lblLibro);
            this.Name = "FormPrestamos";
            this.Text = "Prestamo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblLector;
        private System.Windows.Forms.ComboBox cbLibros;
        private System.Windows.Forms.ComboBox cbLectores;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
    }
}