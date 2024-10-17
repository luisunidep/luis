using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestión_de_Bibliotecas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            // Botón "Gestionar Libros"
            btnGestionarLibros.Click += new EventHandler(BtnGestionarLibros_Click);
            this.Controls.Add(btnGestionarLibros);

            // Botón "Gestionar Préstamos"
            btnGestionarPrestamos.Click += new EventHandler(BtnGestionarPrestamos_Click);
            this.Controls.Add(btnGestionarPrestamos);

            // Botón "Gestionar Lectores"
            btnGestionarLectores.Click += new EventHandler(BtnGestionarLectores_Click);
            this.Controls.Add(btnGestionarLectores);

            // Botón "Gestionar Autores"
            btnGestionarAutores.Click += new EventHandler(BtnGestionarAutores_Click);
            this.Controls.Add(btnGestionarAutores);
        }

        // Métodos para los botones
        private void BtnGestionarLibros_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario de gestión de libros
            FormLibros formLibros = new FormLibros();
            formLibros.Show();
        }

        private void BtnGestionarPrestamos_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario de gestión de préstamos
            FormPrestamos formPrestamos = new FormPrestamos();
            formPrestamos.Show();
        }

        private void BtnGestionarLectores_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario de gestión de lectores
            FormLectores formLectores = new FormLectores();
            formLectores.Show();
        }

        private void BtnGestionarAutores_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario de gestión de Autores
            FormAutor formAutor = new FormAutor();
            formAutor.Show();
        }
         private void btnSalir_Click(object sender, EventArgs e)
        {
        this.Close();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            // Inicializamos el Timer
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizamos el ToolStripStatusLabel con la fecha y hora actual
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
