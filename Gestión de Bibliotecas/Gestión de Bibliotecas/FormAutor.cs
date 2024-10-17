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
using static Gestión_de_Bibliotecas.FormLectores;

namespace Gestión_de_Bibliotecas
{
    // Clase Autor que hereda de Persona
    public partial class FormAutor : Form
    {
        static string connectionString = "Data Source=DESKTOP-KHFO99J\\luis2;Initial Catalog=BibliotecaDB;User ID=sa;Password=123456;TrustServerCertificate=True";

        // Lista para almacenar los autores
        private List<Autor> listaAutores = new List<Autor>();

        public FormAutor()
        {
            InitializeComponent();
            InicializarFormulario();
            CargarAutorDesdeBaseDeDatos();
        }

        private void InicializarFormulario()
        {
            // Botones para agregar, editar y eliminar autores
            btnAgregar.Click += (sender, e) => BtnAgregar_Click();
            btnEditar.Click += (sender, e) => BtnEditar_Click();
            btnEliminar.Click += (sender, e) => BtnEliminar_Click();
            btnGuardarCambios.Enabled = false;
            btnGuardarCambios.Click += (sender, e) => BtnGuardarCambios_Click();

            // DataGridView para mostrar la lista de autores
            dgvAutores.Columns.Add("Nombre", "Nombre");
            dgvAutores.Columns.Add("Apellido", "Apellido");
            dgvAutores.Columns.Add("Nacionalidad", "Nacionalidad");
        }

        // Carga autores desde la base de datos
        private void CargarAutorDesdeBaseDeDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Nombre, Apellido, Nacionalidad FROM Autor";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listaAutores.Clear(); // Limpiar la lista antes de cargar nuevos autores
                    dgvAutores.Rows.Clear(); // Limpiar el DataGridView

                    foreach (DataRow row in dt.Rows)
                    {
                        var autor = new Autor
                        {
                            Nombre = row["Nombre"].ToString(),
                            Apellido = row["Apellido"].ToString(),
                            Nacionalidad = row["Nacionalidad"].ToString()
                        };
                        listaAutores.Add(autor);
                        dgvAutores.Rows.Add(autor.Nombre, autor.Apellido, autor.Nacionalidad);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar autores: " + ex.Message);
                }
            }
        }

        // Evento para agregar un nuevo autor
        private void BtnAgregar_Click()
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                Autor nuevoAutor = new Autor
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nacionalidad = txtNacionalidad.Text
                };

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Autor (Nombre, Apellido, Nacionalidad) VALUES (@Nombre, @Apellido, @Nacionalidad)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nombre", nuevoAutor.Nombre);
                            command.Parameters.AddWithValue("@Apellido", nuevoAutor.Apellido);
                            command.Parameters.AddWithValue("@Nacionalidad", nuevoAutor.Nacionalidad);
                            command.ExecuteNonQuery();
                        }
                    }

                    listaAutores.Add(nuevoAutor);
                    ActualizarDataGridView();
                    LimpiarCampos();
                    MessageBox.Show("Autor agregado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar autor: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }

        // Evento para editar un autor seleccionado
        private void BtnEditar_Click()
        {
            if (dgvAutores.SelectedRows.Count > 0)
            {
                int index = dgvAutores.SelectedRows[0].Index;
                Autor autorSeleccionado = listaAutores[index];

                txtNombre.Text = autorSeleccionado.Nombre;
                txtApellido.Text = autorSeleccionado.Apellido;
                txtNacionalidad.Text = autorSeleccionado.Nacionalidad;

                btnGuardarCambios.Tag = index; // Guardamos el índice en el botón
                btnGuardarCambios.Enabled = true; // Activamos el botón de guardar cambios
            }
            else
            {
                MessageBox.Show("Seleccione un autor para editar.");
            }
        }

        // Evento para guardar los cambios del autor editado
        private void BtnGuardarCambios_Click()
        {
            if (btnGuardarCambios.Tag is int index)
            {
                // Actualizamos los datos del autor en la lista
                listaAutores[index].Nombre = txtNombre.Text;
                listaAutores[index].Apellido = txtApellido.Text;
                listaAutores[index].Nacionalidad = txtNacionalidad.Text;

                ActualizarDataGridView();
                LimpiarCampos();
                btnGuardarCambios.Enabled = false; // Desactiva el botón de guardar cambios
                MessageBox.Show("Autor editado exitosamente.");
            }
        }

        // Evento para eliminar un autor seleccionado
        private void BtnEliminar_Click()
        {
            if (dgvAutores.SelectedRows.Count > 0)
            {
                int index = dgvAutores.SelectedRows[0].Index;
                listaAutores.RemoveAt(index);
                ActualizarDataGridView();
                MessageBox.Show("Autor eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un autor para eliminar.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para actualizar el DataGridView con la lista de autores
        private void ActualizarDataGridView()
        {
            dgvAutores.Rows.Clear();

            foreach (Autor autor in listaAutores)
            {
                dgvAutores.Rows.Add(autor.Nombre, autor.Apellido, autor.Nacionalidad);
            }
        }

        // Método para limpiar los campos de texto
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNacionalidad.Clear();
        }

        // Clase Autor para gestionar la información
        public class Autor
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nacionalidad { get; set; }
        }
    }
}