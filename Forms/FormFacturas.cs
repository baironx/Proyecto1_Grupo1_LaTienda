using System;
using System.Linq;
using System.Windows.Forms;
using TiendaLaEsquina.Core;

namespace TiendaLaEsquina.Forms
{
    public partial class FormFacturas : Form
    {
        private Factura facturaActual;
        private Cliente clienteSeleccionado;

        public FormFacturas()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ConfigurarDataGridView();
            CargarClientes();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArticulo",
                HeaderText = "Artículo",
                Width = 200
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                Width = 100
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                Width = 80
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                Width = 120
            });
        }

        private void CargarClientes()
        {
            cmbClientes.Items.Clear();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";

            var clientesActivos = GestorDatos.ObtenerClientesActivos();
            foreach (var cliente in clientesActivos)
            {
                cmbClientes.Items.Add(cliente);
            }

            if (cmbClientes.Items.Count > 0)
            {
                cmbClientes.SelectedIndex = 0;
            }
        }

        private void FormFacturas_Load(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem != null)
            {
                clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;
                txtNombreCliente.Text = clienteSeleccionado.Nombre;
                txtDireccionCliente.Text = clienteSeleccionado.Direccion;
                txtTelefonoCliente.Text = clienteSeleccionado.Telefono;

                // Crear una nueva factura si no existe
                if (facturaActual == null)
                {
                    facturaActual = GestorDatos.CrearFactura(clienteSeleccionado);
                    lblNumeroFactura.Text = $"Factura #{facturaActual.NumeroFactura}";
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un cliente seleccionado
                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("Por favor, seleccione un cliente primero.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClientes.Focus();
                    return;
                }

                // Validar los campos del producto
                string nombreProducto = txtArticulo.Text.Trim();
                string precioTexto = txtPrecio.Text.Trim();
                string cantidadTexto = txtCantidad.Text.Trim();

                string errorValidacion = Producto.ValidarProducto(nombreProducto, precioTexto, cantidadTexto);
                if (!string.IsNullOrEmpty(errorValidacion))
                {
                    MessageBox.Show(errorValidacion, "Error de Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el producto
                Producto nuevoProducto = new Producto
                {
                    Id = GestorDatos.ObtenerSiguienteIdProducto(),
                    Nombre = nombreProducto,
                    Precio = decimal.Parse(precioTexto),
                    Cantidad = int.Parse(cantidadTexto)
                };

                // Agregar el producto a la factura
                facturaActual.AgregarProducto(nuevoProducto);

                // Actualizar la tabla
                ActualizarTablaProductos();

                // Actualizar totales
                ActualizarTotales();

                // Limpiar campos de producto
                LimpiarCamposProducto();

                MessageBox.Show("Producto agregado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTablaProductos()
        {
            dgvProductos.Rows.Clear();

            if (facturaActual != null && facturaActual.Productos != null)
            {
                foreach (var producto in facturaActual.Productos)
                {
                    int index = dgvProductos.Rows.Add();
                    dgvProductos.Rows[index].Cells["colArticulo"].Value = producto.Nombre;
                    dgvProductos.Rows[index].Cells["colPrecio"].Value = producto.Precio.ToString("C2");
                    dgvProductos.Rows[index].Cells["colCantidad"].Value = producto.Cantidad;
                    dgvProductos.Rows[index].Cells["colTotal"].Value = producto.Total.ToString("C2");
                }
            }
        }

        private void ActualizarTotales()
        {
            if (facturaActual != null)
            {
                lblSubtotalValor.Text = facturaActual.Subtotal.ToString("C2");
                lblIvaValor.Text = facturaActual.IVA.ToString("C2");
                lblTotalValor.Text = facturaActual.Total.ToString("C2");
            }
            else
            {
                lblSubtotalValor.Text = "₡0.00";
                lblIvaValor.Text = "₡0.00";
                lblTotalValor.Text = "₡0.00";
            }
        }

        private void LimpiarCamposProducto()
        {
            txtArticulo.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtArticulo.Focus();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar este producto?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    int indice = dgvProductos.SelectedRows[0].Index;
                    facturaActual.EliminarProducto(indice);

                    ActualizarTablaProductos();
                    ActualizarTotales();

                    MessageBox.Show("Producto eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que la factura sea válida
                string errorValidacion = Factura.ValidarFactura(facturaActual?.Cliente!, facturaActual?.Productos!);
                if (!string.IsNullOrEmpty(errorValidacion))
                {
                    MessageBox.Show(errorValidacion, "Error de Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar la factura
                bool resultado = GestorDatos.GuardarFactura(facturaActual!, out string mensajeError);

                if (resultado)
                {
                    string mensaje = $"Factura #{facturaActual!.NumeroFactura} guardada exitosamente.\n\n" +
                                   $"Cliente: {facturaActual.Cliente.Nombre}\n" +
                                   $"Subtotal: {facturaActual.Subtotal:C2}\n" +
                                   $"IVA (13%): {facturaActual.IVA:C2}\n" +
                                   $"Total: {facturaActual.Total:C2}";

                    MessageBox.Show(mensaje, "Factura Guardada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar formulario
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar factura: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea limpiar toda la factura?",
                "Confirmar Limpieza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiar datos del cliente
            txtNombreCliente.Clear();
            txtDireccionCliente.Clear();
            txtTelefonoCliente.Clear();

            // Limpiar campos de producto
            LimpiarCamposProducto();

            // Limpiar tabla
            dgvProductos.Rows.Clear();

            // Resetear factura
            facturaActual = null!;
            clienteSeleccionado = null!;

            // Resetear totales
            lblSubtotalValor.Text = "₡0.00";
            lblIvaValor.Text = "₡0.00";
            lblTotalValor.Text = "₡0.00";
            lblNumeroFactura.Text = "Factura #---";

            // Recargar clientes
            if (cmbClientes.Items.Count > 0)
            {
                cmbClientes.SelectedIndex = 0;
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            // Verificar si hay una factura en proceso
            if (facturaActual != null && facturaActual.Productos.Count > 0)
            {
                DialogResult confirmacion = MessageBox.Show(
                    "Hay una factura en proceso. ¿Desea salir sin guardar?",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No)
                {
                    return;
                }
            }

            FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
            menuPrincipal.Show();
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números, punto decimal y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si se está cerrando el formulario y hay factura en proceso
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (facturaActual != null && facturaActual.Productos.Count > 0)
                {
                    DialogResult confirmacion = MessageBox.Show(
                        "Hay una factura en proceso. ¿Desea salir sin guardar?",
                        "Confirmar Salida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
