using System;
using System.Linq;
using System.Windows.Forms;
using TiendaLaEsquina.Core;

namespace TiendaLaEsquina.Forms
{
    public partial class FormMenuPrincipal : Form
    {
        private Cliente clienteEditando = null!;

        public FormMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            
            // Configurar el DataGridView
            ConfigurarDataGridView();
            
            // Cargar datos iniciales
            CargarClientes();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 150
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 200
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 100
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                Width = 80
            });
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            LimpiarCampos();
        }

        private void CargarClientes()
        {
            dgvClientes.Rows.Clear();
            
            foreach (var cliente in GestorDatos.Clientes)
            {
                int index = dgvClientes.Rows.Add();
                dgvClientes.Rows[index].Cells["colId"].Value = cliente.Id;
                dgvClientes.Rows[index].Cells["colNombre"].Value = cliente.Nombre;
                dgvClientes.Rows[index].Cells["colDireccion"].Value = cliente.Direccion;
                dgvClientes.Rows[index].Cells["colTelefono"].Value = cliente.Telefono;
                dgvClientes.Rows[index].Cells["colEstado"].Value = cliente.Activo ? "Activo" : "Inactivo";
                
                // Cambiar color de fila si está inactivo
                if (!cliente.Activo)
                {
                    dgvClientes.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
            clienteEditando = null!;
            btnGuardar.Text = "Agregar";
            btnCancelar.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que no haya un cliente en edición
                if (clienteEditando != null)
                {
                    MessageBox.Show("Está editando un cliente. Primero guarde o cancele la edición.", 
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                // Intentar agregar el cliente usando GestorDatos
                bool resultado = GestorDatos.AgregarCliente(nombre, direccion, telefono, out string mensajeError);

                if (resultado)
                {
                    MessageBox.Show("Cliente agregado exitosamente.", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error de Validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un cliente para modificar.", 
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colId"].Value);
                clienteEditando = GestorDatos.BuscarClientePorId(id);

                if (clienteEditando != null)
                {
                    // Cargar datos en los campos
                    txtNombre.Text = clienteEditando.Nombre;
                    txtDireccion.Text = clienteEditando.Direccion;
                    txtTelefono.Text = clienteEditando.Telefono;
                    chkActivo.Checked = clienteEditando.Activo;

                    btnGuardar.Text = "Actualizar";
                    btnCancelar.Visible = true;
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cliente: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (clienteEditando == null)
                {
                    // Agregar nuevo cliente
                    btnAgregar_Click(sender, e);
                }
                else
                {
                    // Actualizar cliente existente
                    bool resultado = GestorDatos.ModificarCliente(
                        clienteEditando.Id, nombre, direccion, telefono, out string mensajeError);

                    if (resultado)
                    {
                        // Actualizar estado si cambió
                        if (chkActivo.Checked)
                            GestorDatos.ActivarCliente(clienteEditando.Id, out _);
                        else
                            GestorDatos.InactivarCliente(clienteEditando.Id, out _);

                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error de Validación", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un cliente para inactivar.", 
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colId"].Value);
                string nombre = dgvClientes.SelectedRows[0].Cells["colNombre"].Value.ToString()!;

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea inactivar al cliente '{nombre}'?", 
                    "Confirmar Inactivación", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = GestorDatos.InactivarCliente(id, out string mensajeError);

                    if (resultado)
                    {
                        MessageBox.Show("Cliente inactivado exitosamente.", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inactivar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    MessageBox.Show("Ingrese un nombre para buscar.", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clientes = GestorDatos.BuscarClientesPorNombre(busqueda);

                if (clientes.Count > 0)
                {
                    MessageBox.Show($"Se encontraron {clientes.Count} cliente(s).", "Resultado", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Actualizar grid solo con los resultados
                    dgvClientes.Rows.Clear();
                    foreach (var cliente in clientes)
                    {
                        int index = dgvClientes.Rows.Add();
                        dgvClientes.Rows[index].Cells["colId"].Value = cliente.Id;
                        dgvClientes.Rows[index].Cells["colNombre"].Value = cliente.Nombre;
                        dgvClientes.Rows[index].Cells["colDireccion"].Value = cliente.Direccion;
                        dgvClientes.Rows[index].Cells["colTelefono"].Value = cliente.Telefono;
                        dgvClientes.Rows[index].Cells["colEstado"].Value = cliente.Activo ? "Activo" : "Inactivo";
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron clientes con ese nombre.", "Sin Resultados", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarClientes();
            LimpiarCampos();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            FormFacturas formFacturas = new FormFacturas();
            formFacturas.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea cerrar sesión?", 
                "Confirmar", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?", 
                "Confirmar Salida", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números, guiones, espacios y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && 
                e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir letras, espacios y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si se está cerrando el formulario pero no es por cerrar sesión ni salir, preguntar
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea salir del sistema?", 
                    "Confirmar Salida", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
