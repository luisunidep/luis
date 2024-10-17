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
    // Clase Lector que hereda de Persona
    public partial class FormLectores : Form
    {
        static string connectionString = "Data Source=DESKTOP-KHFO99J\\luis2;Initial Catalog=BibliotecaDB;User ID=sa;Password=123456;TrustServerCertificate=True";

        // Lista para almacenar los lectores
        private List<Lector> listaLectores = new List<Lector>();

        public FormLectores()
        {
            InitializeComponent();
            InicializarFormulario();
            CargarLectoresDesdeBaseDeDatos();
        }

        private void InicializarFormulario()
        {
            // Botones para agregar, editar y eliminar lectores
            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // Configuración inicial del botón de guardar cambios
            btnGuardarCambios.Enabled = false;
            btnGuardarCambios.Click += BtnGuardarCambios_Click;

            // DataGridView para mostrar la lista de lectores
            dgvLectores.Columns.Add("Nombre", "Nombre");
            dgvLectores.Columns.Add("Apellido", "Apellido");
            dgvLectores.Columns.Add("Email", "Email");

            // Añadir controles al formulario
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblApellido);
            this.Controls.Add(txtApellido);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnEliminar);
            this.Controls.Add(btnGuardarCambios);  // Botón de guardar cambios
            this.Controls.Add(dgvLectores);
        }

        // Método para cargar los lectores desde la base de datos al DataGridView
        private void CargarLectoresDesdeBaseDeDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Nombre, Apellido, Email FROM Lectores";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listaLectores.Clear(); // Limpiar la lista antes de cargar nuevos lectores
                    dgvLectores.Rows.Clear(); // Limpiar el DataGridView

                    foreach (DataRow row in dt.Rows)
                    {
                        var lector = new Lector
                        {
                            Nombre = row["Nombre"].ToString(),
                            Apellido = row["Apellido"].ToString(),
                            Email = row["Email"].ToString()
                        };
                        listaLectores.Add(lector);
                        dgvLectores.Rows.Add(lector.Nombre, lector.Apellido, lector.Email);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar lectores: " + ex.Message);
                }
            }
        }

        // Evento para agregar un nuevo lector
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Lector nuevoLector = new Lector
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text
                };

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Lectores (Nombre, Apellido, Email) VALUES (@Nombre, @Apellido, @Email)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nombre", nuevoLector.Nombre);
                            command.Parameters.AddWithValue("@Apellido", nuevoLector.Apellido);
                            command.Parameters.AddWithValue("@Email", nuevoLector.Email);

                            command.ExecuteNonQuery();
                        }
                    }

                    listaLectores.Add(nuevoLector);
                    ActualizarDataGridView(); // Refrescar el DataGridView
                    LimpiarCampos();
                    MessageBox.Show("Lector agregado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar lector: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }

        // Evento para eliminar un lector seleccionado
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLectores.SelectedRows.Count > 0)
            {
                string nombre = dgvLectores.SelectedRows[0].Cells["Nombre"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Lectores WHERE Nombre = @Nombre";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Lector eliminado exitosamente.");
                        CargarLectoresDesdeBaseDeDatos(); // Refrescar la lista
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el lector: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un lector para eliminar.");
            }
        }

        // Evento para editar un lector seleccionado
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLectores.SelectedRows.Count > 0)
            {
                int index = dgvLectores.SelectedRows[0].Index;
                Lector lectorSeleccionado = listaLectores[index];

                // Mostrar los datos del lector en los TextBox
                txtNombre.Text = lectorSeleccionado.Nombre;
                txtApellido.Text = lectorSeleccionado.Apellido;
                txtEmail.Text = lectorSeleccionado.Email;

                // Almacenar el índice temporalmente en el botón de guardar cambios
                btnGuardarCambios.Tag = index;
                btnGuardarCambios.Enabled = true;  // Activar el botón de guardar cambios
            }
            else
            {
                MessageBox.Show("Seleccione un lector para editar.");
            }
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (btnGuardarCambios.Tag != null)
            {
                int index = (int)btnGuardarCambios.Tag; // Recuperar el índice del lector

                // Actualizar los datos en la lista de lectores
                listaLectores[index].Nombre = txtNombre.Text;
                listaLectores[index].Apellido = txtApellido.Text;
                listaLectores[index].Email = txtEmail.Text;

                // Actualizar la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Lectores SET Apellido = @Apellido, Email = @Email WHERE Nombre = @Nombre";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nombre", listaLectores[index].Nombre); // Aquí deberías usar un identificador único si lo tienes
                        command.Parameters.AddWithValue("@Apellido", listaLectores[index].Apellido);
                        command.Parameters.AddWithValue("@Email", listaLectores[index].Email);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar lector: {ex.Message}");
                    }
                }

                ActualizarDataGridView();  // Refrescar el DataGridView
                LimpiarCampos();  // Limpiar los TextBox

                btnGuardarCambios.Enabled = false;  // Desactivar el botón
                MessageBox.Show("Lector editado exitosamente.");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
                {
            this.Close();
        }
        // Método para actualizar el DataGridView con la lista de lectores
        private void ActualizarDataGridView()
        {
            dgvLectores.Rows.Clear();

            foreach (Lector lector in listaLectores)
            {
                dgvLectores.Rows.Add(lector.Nombre, lector.Apellido, lector.Email);
            }
        }

        // Método para limpiar los campos de texto
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
        }

        // Clase Lector para gestionar la información
        public class Lector
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
        }

        
    }
}