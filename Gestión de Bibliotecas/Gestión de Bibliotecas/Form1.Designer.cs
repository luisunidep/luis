namespace Gestión_de_Bibliotecas
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnGestionarLibros = new System.Windows.Forms.Button();
            this.btnGestionarPrestamos = new System.Windows.Forms.Button();
            this.btnGestionarLectores = new System.Windows.Forms.Button();
            this.btnGestionarAutores = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(597, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnGestionarLibros
            // 
            this.btnGestionarLibros.BackColor = System.Drawing.Color.Navy;
            this.btnGestionarLibros.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarLibros.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarLibros.Location = new System.Drawing.Point(34, 115);
            this.btnGestionarLibros.Name = "btnGestionarLibros";
            this.btnGestionarLibros.Size = new System.Drawing.Size(237, 58);
            this.btnGestionarLibros.TabIndex = 4;
            this.btnGestionarLibros.Text = "Gestionar Libros";
            this.btnGestionarLibros.UseVisualStyleBackColor = false;
            // 
            // btnGestionarPrestamos
            // 
            this.btnGestionarPrestamos.BackColor = System.Drawing.Color.Navy;
            this.btnGestionarPrestamos.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarPrestamos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarPrestamos.Location = new System.Drawing.Point(325, 115);
            this.btnGestionarPrestamos.Name = "btnGestionarPrestamos";
            this.btnGestionarPrestamos.Size = new System.Drawing.Size(237, 58);
            this.btnGestionarPrestamos.TabIndex = 5;
            this.btnGestionarPrestamos.Text = "Gestionar Prestamos";
            this.btnGestionarPrestamos.UseVisualStyleBackColor = false;
            // 
            // btnGestionarLectores
            // 
            this.btnGestionarLectores.BackColor = System.Drawing.Color.Navy;
            this.btnGestionarLectores.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarLectores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarLectores.Location = new System.Drawing.Point(34, 190);
            this.btnGestionarLectores.Name = "btnGestionarLectores";
            this.btnGestionarLectores.Size = new System.Drawing.Size(237, 53);
            this.btnGestionarLectores.TabIndex = 6;
            this.btnGestionarLectores.Text = "Gestionar Lectores";
            this.btnGestionarLectores.UseVisualStyleBackColor = false;
            // 
            // btnGestionarAutores
            // 
            this.btnGestionarAutores.BackColor = System.Drawing.Color.Navy;
            this.btnGestionarAutores.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarAutores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarAutores.Location = new System.Drawing.Point(325, 190);
            this.btnGestionarAutores.Name = "btnGestionarAutores";
            this.btnGestionarAutores.Size = new System.Drawing.Size(237, 53);
            this.btnGestionarAutores.TabIndex = 7;
            this.btnGestionarAutores.Text = "Gestionar Autores";
            this.btnGestionarAutores.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "SISTEMA DE GESTIÓN DE BIBLIOTECA";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(259, 249);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(79, 29);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(597, 372);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGestionarAutores);
            this.Controls.Add(this.btnGestionarLectores);
            this.Controls.Add(this.btnGestionarPrestamos);
            this.Controls.Add(this.btnGestionarLibros);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnGestionarLibros;
        private System.Windows.Forms.Button btnGestionarPrestamos;
        private System.Windows.Forms.Button btnGestionarLectores;
        private System.Windows.Forms.Button btnGestionarAutores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
    }
}

