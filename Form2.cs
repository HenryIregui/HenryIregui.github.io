using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionPersonas
{
    public partial class Form2 : Form
    {
        private int idOriginal;

        public int IdActualizado { get; private set; }
        public string NombreActualizado { get; private set; }
        public int EdadActualizada { get; private set; }

        public Form2(int idPersona, string nombre, int edad)
        {
            InitializeComponent();

            idOriginal = idPersona;

            txtId.Text = idPersona.ToString();
            txtNombre.Text = nombre;
            txtEdad.Text = edad.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de datos ingresados
            if (
                int.TryParse(txtId.Text, out int nuevoId) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                int.TryParse(txtEdad.Text, out int nuevaEdad) &&
                nuevaEdad > 0
            )
            {
                string connectionString = "Server=localhost;Database=crud_app;Uid=root;Pwd=;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Validar que el nuevo ID no esté duplicado si se cambió
                    if (nuevoId != idOriginal)
                    {
                        string checkQuery = "SELECT COUNT(*) FROM personas WHERE id = @id";
                        var checkCmd = new MySqlCommand(checkQuery, connection);
                        checkCmd.Parameters.AddWithValue("@id", nuevoId);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("❌ El nuevo ID ya está en uso.");
                            return;
                        }
                    }

                    // Actualizar el registro
                    string updateQuery = "UPDATE personas SET id = @nuevoId, nombre = @nombre, edad = @edad WHERE id = @idOriginal";
                    var updateCmd = new MySqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@nuevoId", nuevoId);
                    updateCmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    updateCmd.Parameters.AddWithValue("@edad", nuevaEdad);
                    updateCmd.Parameters.AddWithValue("@idOriginal", idOriginal);

                    int affectedRows = updateCmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        // Guardar valores para devolver al formulario principal
                        IdActualizado = nuevoId;
                        NombreActualizado = txtNombre.Text;
                        EdadActualizada = nuevaEdad;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("❌ No se pudo actualizar el registro.");
                    }
                }
            }
            else
            {
                MessageBox.Show("❌ Datos inválidos. Verifica el ID, nombre y edad.");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Puedes usar este método si deseas ejecutar algo al cargar el formulario.
        }
    }
}
