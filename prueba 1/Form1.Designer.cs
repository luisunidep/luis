namespace prueba_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnVerResultados = new Button();
            SuspendLayout();
            // 
            // btnVerResultados
            // 
            btnVerResultados.Location = new Point(343, 149);
            btnVerResultados.Name = "btnVerResultados";
            btnVerResultados.Size = new Size(166, 102);
            btnVerResultados.TabIndex = 0;
            btnVerResultados.Text = "button1";
            btnVerResultados.UseVisualStyleBackColor = true;
            btnVerResultados.Click += btnVerResultados_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerResultados);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnVerResultados;
    }
}
