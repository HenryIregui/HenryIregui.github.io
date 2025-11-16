using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionPersonas
{
    public partial class Form1 : Form
    {
        private List<Persona> personas;

        public Form1()
        {
            InitializeComponent();
            personas = new List<Persona>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idStr = txtId.Text;
            string nombre = txtNombre.Text;
            string edadStr = txtEdad.Text;

            if (string.IsNullOrEmpty(idStr) || string.IsNullOrEmpty(nombre) || !int.TryParse(edadStr, out int edad) || edad <= 0)
            {
                MessageBox.Show("Por favor, ingresa un ID, nombre y una edad válida.");
                return;
            }

            int id = int.Parse(idStr);

            string connectionString = "Server=localhost;Database=crud_app;Uid=root;Pwd=;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM personas WHERE id = @id";
                var checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@id", id);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Ya existe una persona con este ID.");
                    return;
                }

                string insertQuery = "INSERT INTO personas (id, nombre, edad) VALUES (@id, @nombre, @edad)";
                var insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@id", id);
                insertCmd.Parameters.AddWithValue("@nombre", nombre);
                insertCmd.Parameters.AddWithValue("@edad", edad);
                insertCmd.ExecuteNonQuery();
            }

            var persona = new Persona { Id = id, Nombre = nombre, Edad = edad };
            personas.Add(persona);
            listBoxPersonas.Items.Add($"{persona.Id}: {persona.Nombre}, {persona.Edad} años");

            txtId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxPersonas.SelectedIndex != -1)
            {
                var personaSeleccionada = listBoxPersonas.SelectedItem.ToString();
                int idSeleccionado = int.Parse(personaSeleccionada.Split(':')[0]);

                string connectionString = "Server=localhost;Database=crud_app;Uid=root;Pwd=;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM personas WHERE id = @id";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                var personaAEliminar = personas.Find(p => p.Id == idSeleccionado);
                if (personaAEliminar != null)
                {
                    personas.Remove(personaAEliminar);
                    listBoxPersonas.Items.RemoveAt(listBoxPersonas.SelectedIndex);
                    MessageBox.Show("Persona eliminada correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una persona para eliminar.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los cambios se han guardado en la base de datos automáticamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listBoxPersonas.SelectedIndex >= 0)
            {
                var personaOriginal = personas[listBoxPersonas.SelectedIndex];

                Form2 editor = new Form2(personaOriginal.Id, personaOriginal.Nombre, personaOriginal.Edad);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    // Verificar si cambió el ID
                    bool idCambiado = editor.IdActualizado != personaOriginal.Id;

                    // Actualizar objeto en memoria
                    personaOriginal.Id = editor.IdActualizado;
                    personaOriginal.Nombre = editor.NombreActualizado;
                    personaOriginal.Edad = editor.EdadActualizada;

                    // Actualizar visualización en el ListBox
                    listBoxPersonas.Items[listBoxPersonas.SelectedIndex] =
                        $"{personaOriginal.Id}: {personaOriginal.Nombre}, {personaOriginal.Edad} años";

                    if (idCambiado)
                    {
                        MessageBox.Show("Persona actualizada correctamente (con nuevo ID).");
                    }
                    else
                    {
                        MessageBox.Show("Persona actualizada correctamente.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una persona para editar.");
            }
        }

        private void CargarDatos()
        {
            string connectionString = "Server=localhost;Database=crud_app;Uid=root;Pwd=;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre, edad FROM personas";
                var cmd = new MySqlCommand(query, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        int edad = reader.GetInt32(2);
                        var persona = new Persona { Id = id, Nombre = nombre, Edad = edad };
                        personas.Add(persona);
                        listBoxPersonas.Items.Add($"{persona.Id}: {persona.Nombre}, {persona.Edad} años");
                    }
                }
            }
        }

        private void listBoxPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento opcional para manejar selección
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            // Evento opcional para manejar cambios en el ID
        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
