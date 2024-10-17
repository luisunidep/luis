using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestión_de_Bibliotecas
{
    // Clase Préstamo para gestionar préstamos de libros
    public partial class FormPrestamos : Form
    {
        static string connectionString = "Data Source=DESKTOP-KHFO99J\\luis2;Initial Catalog=BibliotecaDB;User ID=sa;Password=123456;TrustServerCertificate=True";

        // Listas para gestionar los préstamos y el historial
        private List<Prestamo> prestamosActivos = new List<Prestamo>();
        private List<Prestamo> historialPrestamos = new List<Prestamo>();

        public FormPrestamos()
        {
            InitializeComponent();
            InicializarFormulario();
            CargarLibrosEnComboBox();
            CargarLectoresEnComboBox();
        }

        private void InicializarFormulario()
        {
            // Configura el DataGridView
            dgvPrestamos.Columns.Add("Libro", "Libro");
            dgvPrestamos.Columns.Add("Lector", "Lector");
            dgvPrestamos.Columns.Add("FechaPrestamo", "Fecha Préstamo");
            dgvPrestamos.Columns.Add("FechaDevolucion", "Fecha Devolución");

            // Asigna eventos a botones
            btnRegistrar.Click += BtnRegistrar_Click;
            btnDevolver.Click += BtnDevolver_Click;
            btnHistorial.Click += BtnHistorial_Click;
        }

        private void CargarLibrosEnComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Titulo FROM Libros";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cbLibros.Items.Add(reader["Titulo"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar libros: " + ex.Message);
                }
            }
        }

        private void CargarLectoresEnComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM Lectores";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cbLectores.Items.Add(reader["NombreCompleto"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar lectores: " + ex.Message);
                }
            }
        }

        // Evento para registrar un préstamo
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbLibros.SelectedItem != null && cbLectores.SelectedItem != null)
            {
                Prestamo nuevoPrestamo = new Prestamo
                {
                    Libro = cbLibros.SelectedItem.ToString(),
                    Lector = cbLectores.SelectedItem.ToString(),
                    FechaPrestamo = DateTime.Now,
                    FechaDevolucion = null
                };

                prestamosActivos.Add(nuevoPrestamo);
                ActualizarDataGridView();
                MessageBox.Show("Préstamo registrado exitosamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un libro y un lector.");
            }
        }

        // Evento para devolver un libro
        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count > 0)
            {
                int index = dgvPrestamos.SelectedRows[0].Index;
                Prestamo prestamoDevuelto = prestamosActivos[index];

                // Asignar la fecha de devolución
                prestamoDevuelto.FechaDevolucion = DateTime.Now;

                // Mover a historial y eliminar de préstamos activos
                historialPrestamos.Add(prestamoDevuelto);
                prestamosActivos.RemoveAt(index);

                ActualizarDataGridView();
                MessageBox.Show("Libro devuelto exitosamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para devolver.");
            }
        }

        // Evento para ver el historial de préstamos
        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            string historial = string.Join(Environment.NewLine,
                historialPrestamos.Select(p =>
                    $"{p.Libro} - {p.Lector} - {p.FechaPrestamo:dd/MM/yyyy} - " +
                    $"{(p.FechaDevolucion.HasValue ? p.FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente")}"));

            MessageBox.Show(string.IsNullOrEmpty(historial) ? "No hay historial de préstamos." : historial, "Historial de Préstamos");
        }
        private void btnSalir_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        // Método para actualizar el DataGridView con los préstamos activos
        private void ActualizarDataGridView()
        {
            dgvPrestamos.Rows.Clear();

            foreach (Prestamo prestamo in prestamosActivos)
            {
                dgvPrestamos.Rows.Add(
                    prestamo.Libro,
                    prestamo.Lector,
                    prestamo.FechaPrestamo.ToString("dd/MM/yyyy"),
                    prestamo.FechaDevolucion.HasValue ? prestamo.FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente"
                );
            }
        }

        // Clase Prestamo para gestionar los datos
        public class Prestamo
        {
            public string Libro { get; set; }
            public string Lector { get; set; }
            public DateTime FechaPrestamo { get; set; }
            public DateTime? FechaDevolucion { get; set; } // Puede ser nulo si no ha sido devuelto
        }

        
    }
}
