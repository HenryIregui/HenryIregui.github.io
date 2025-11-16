namespace GestionPersonas
{
    // Clase parcial que representa la interfaz de usuario principal de la aplicación.
    partial class Form1
    {
        // Declaración de los componentes de la interfaz (controles).
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListBox listBoxPersonas;
        private System.Windows.Forms.Button btnEditar;

        // Método para liberar los recursos utilizados por los componentes.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Libera los recursos asociados a los controles.
            }
            base.Dispose(disposing); // Llama al Dispose base.
        }

        // Método de inicialización que configura los controles y su disposición en la pantalla.
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.listBoxPersonas = new System.Windows.Forms.ListBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(14, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 16);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(78, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(582, 22);
            this.txtId.TabIndex = 9;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(14, 47);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 16);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(78, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(582, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(14, 79);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(43, 16);
            this.lblEdad.TabIndex = 6;
            this.lblEdad.Text = "Edad:";
            // 
            // txtEdad
            // 
            this.txtEdad.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdad.Location = new System.Drawing.Point(78, 76);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(582, 22);
            this.txtEdad.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(14, 106);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 25);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(106, 106);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 25);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // listBoxPersonas
            // 
            this.listBoxPersonas.FormattingEnabled = true;
            this.listBoxPersonas.ItemHeight = 16;
            this.listBoxPersonas.Location = new System.Drawing.Point(14, 137);
            this.listBoxPersonas.Name = "listBoxPersonas";
            this.listBoxPersonas.Size = new System.Drawing.Size(646, 148);
            this.listBoxPersonas.TabIndex = 2;
            this.listBoxPersonas.SelectedIndexChanged += new System.EventHandler(this.listBoxPersonas_SelectedIndexChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(198, 106);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(86, 25);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1131, 478);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.listBoxPersonas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Name = "Form1";
            this.Text = "Gestión de Personas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
