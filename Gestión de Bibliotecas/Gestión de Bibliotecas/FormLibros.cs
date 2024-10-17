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
    // Clase Libro con propiedades de ISBN, Título, Autor
    public partial class FormLibros : Form
    {
        static string connectionString = "Data Source=DESKTOP-KHFO99J\\luis2;Initial Catalog=BibliotecaDB;User ID=sa;Password=123456;TrustServerCertificate=True";

        // Lista para almacenar los libros
        private List<Libro> libros = new List<Libro>();

        public FormLibros()
        {
            InitializeComponent();
            InicializarFormulario();
            CargarLibrosDesdeBaseDeDatos();
        }

        private void InicializarFormulario()
        {
            // Configurar botones
            btnAgregar.Click += BtnAgregar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            
            btnEliminar.Click += BtnEliminar_Click;

            // Configurar DataGridView
            dgvLibros.Columns.Add("ISBN", "ISBN");
            dgvLibros.Columns.Add("Título", "Título");
            dgvLibros.Columns.Add("Autor", "Autor");
            dgvLibros.Columns.Add("Categoría", "Categoría");
            dgvLibros.Columns.Add("Editorial", "Editorial");
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Añadir controles al formulario
            this.Controls.Add(lblISBN);
            this.Controls.Add(txtISBN);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(txtTitulo);
            this.Controls.Add(lblAutor);
            this.Controls.Add(txtAutor);
            this.Controls.Add(lblCategoria);
            this.Controls.Add(txtCategoria);
            this.Controls.Add(lblEditorial);
            this.Controls.Add(txtEditorial);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(dgvLibros);
           
            this.Controls.Add(btnEliminar);
        }

        // Evento para agregar libro
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtISBN.Text) || string.IsNullOrEmpty(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            var nuevoLibro = new Libro
            {
                ISBN = txtISBN.Text,
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Categoria = txtCategoria.Text,
                Editorial = txtEditorial.Text
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Libros (ISBN, Titulo, Autor, Categoria, Editorial) VALUES (@ISBN, @Titulo, @Autor, @Categoria, @Editorial)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ISBN", nuevoLibro.ISBN);
                        command.Parameters.AddWithValue("@Titulo", nuevoLibro.Titulo);
                        command.Parameters.AddWithValue("@Autor", nuevoLibro.Autor);
                        command.Parameters.AddWithValue("@Categoria", nuevoLibro.Categoria);
                        command.Parameters.AddWithValue("@Editorial", nuevoLibro.Editorial);
                        command.ExecuteNonQuery();
                    }
                }

                LimpiarCampos();
                CargarLibrosDesdeBaseDeDatos(); // Refrescar la lista
                MessageBox.Show("Libro agregado exitosamente.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al agregar libro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        // Método para cargar los libros desde la base de datos al DataGridView
        private void CargarLibrosDesdeBaseDeDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ISBN, Titulo, Autor, Categoria, Editorial FROM Libros";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    libros.Clear(); // Limpiar la lista antes de cargar nuevos libros
                    dgvLibros.Rows.Clear(); // Limpiar el DataGridView

                    foreach (DataRow row in dt.Rows)
                    {
                        var libro = new Libro
                        {
                            ISBN = row["ISBN"].ToString(),
                            Titulo = row["Titulo"].ToString(),
                            Autor = row["Autor"].ToString(),
                            Categoria = row["Categoria"].ToString(),
                            Editorial = row["Editorial"].ToString()
                        };
                        libros.Add(libro);
                        dgvLibros.Rows.Add(libro.ISBN, libro.Titulo, libro.Autor, libro.Categoria, libro.Editorial);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar libros: " + ex.Message);
                }
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtCategoria.Clear();
            txtEditorial.Clear();
        }

        // Evento para eliminar un libro seleccionado
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                string isbn = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Libros WHERE ISBN = @ISBN";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ISBN", isbn);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Libro eliminado exitosamente.");
                        CargarLibrosDesdeBaseDeDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el libro: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro para eliminar.");
            }
        }

        // Evento para buscar libros
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var resultados = libros.FindAll(libro =>
                libro.ISBN.IndexOf(txtISBN.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                libro.Titulo.IndexOf(txtTitulo.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (resultados.Count > 0)
            {
                ActualizarDataGridView(resultados);
                MessageBox.Show($"Se encontraron {resultados.Count} libros.");
            }
            else
            {
                MessageBox.Show("No se encontraron libros.");
            }
        }

        // Método para actualizar el DataGridView con una lista de libros
        private void ActualizarDataGridView(List<Libro> listaLibros)
        {
            dgvLibros.Rows.Clear();
            foreach (var libro in listaLibros)
            {
                dgvLibros.Rows.Add(libro.ISBN, libro.Titulo, libro.Autor, libro.Categoria, libro.Editorial);
            }
        }

        // Evento para editar libro
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                string isbnOriginal = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();
                var libro = libros.FirstOrDefault(l => l.ISBN == isbnOriginal);

                if (libro != null)
                {
                    // Actualizar valores
                    libro.ISBN = txtISBN.Text;
                    libro.Titulo = txtTitulo.Text;
                    libro.Autor = txtAutor.Text;
                    libro.Categoria = txtCategoria.Text;
                    libro.Editorial = txtEditorial.Text;

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, Categoria = @Categoria, Editorial = @Editorial WHERE ISBN = @ISBN";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ISBN", isbnOriginal);
                                command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                                command.Parameters.AddWithValue("@Autor", libro.Autor);
                                command.Parameters.AddWithValue("@Categoria", libro.Categoria);
                                command.Parameters.AddWithValue("@Editorial", libro.Editorial);
                                command.ExecuteNonQuery();
                            }
                        }

                        CargarLibrosDesdeBaseDeDatos(); // Refrescar la lista
                        MessageBox.Show("Libro editado correctamente.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error al editar libro: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro para editar.");
            }
        }

        // Evento para salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Clase Libro
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Editorial { get; set; }
    }
}
