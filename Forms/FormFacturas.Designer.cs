namespace TiendaLaEsquina.Forms
{
    partial class FormFacturas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.txtDireccionCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.groupBoxProductos = new System.Windows.Forms.GroupBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.groupBoxTotales = new System.Windows.Forms.GroupBox();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblSubtotalValor = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnGuardarFactura = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.groupBoxCliente.SuspendLayout();
            this.groupBoxProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBoxTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(280, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(360, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Facturación";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNumeroFactura.Location = new System.Drawing.Point(380, 65);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(134, 25);
            this.lblNumeroFactura.TabIndex = 1;
            this.lblNumeroFactura.Text = "Factura #---";
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.txtTelefonoCliente);
            this.groupBoxCliente.Controls.Add(this.txtDireccionCliente);
            this.groupBoxCliente.Controls.Add(this.txtNombreCliente);
            this.groupBoxCliente.Controls.Add(this.cmbClientes);
            this.groupBoxCliente.Controls.Add(this.lblTelefono);
            this.groupBoxCliente.Controls.Add(this.lblDireccion);
            this.groupBoxCliente.Controls.Add(this.lblNombre);
            this.groupBoxCliente.Controls.Add(this.lblCliente);
            this.groupBoxCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCliente.Location = new System.Drawing.Point(20, 110);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(880, 150);
            this.groupBoxCliente.TabIndex = 2;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Información del Cliente";
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefonoCliente.Location = new System.Drawing.Point(570, 100);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.ReadOnly = true;
            this.txtTelefonoCliente.Size = new System.Drawing.Size(280, 25);
            this.txtTelefonoCliente.TabIndex = 7;
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccionCliente.Location = new System.Drawing.Point(570, 60);
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.ReadOnly = true;
            this.txtDireccionCliente.Size = new System.Drawing.Size(280, 25);
            this.txtDireccionCliente.TabIndex = 6;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreCliente.Location = new System.Drawing.Point(150, 100);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(280, 25);
            this.txtNombreCliente.TabIndex = 5;
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(150, 40);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(280, 25);
            this.cmbClientes.TabIndex = 4;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTelefono.Location = new System.Drawing.Point(480, 103);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(64, 19);
            this.lblTelefono.TabIndex = 3;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDireccion.Location = new System.Drawing.Point(480, 63);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(70, 19);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(30, 103);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 19);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCliente.Location = new System.Drawing.Point(30, 43);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(116, 19);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Seleccionar Cliente:";
            // 
            // groupBoxProductos
            // 
            this.groupBoxProductos.Controls.Add(this.btnEliminarProducto);
            this.groupBoxProductos.Controls.Add(this.btnAgregarProducto);
            this.groupBoxProductos.Controls.Add(this.txtCantidad);
            this.groupBoxProductos.Controls.Add(this.txtPrecio);
            this.groupBoxProductos.Controls.Add(this.txtArticulo);
            this.groupBoxProductos.Controls.Add(this.lblCantidad);
            this.groupBoxProductos.Controls.Add(this.lblPrecio);
            this.groupBoxProductos.Controls.Add(this.lblArticulo);
            this.groupBoxProductos.Controls.Add(this.dgvProductos);
            this.groupBoxProductos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxProductos.Location = new System.Drawing.Point(20, 280);
            this.groupBoxProductos.Name = "groupBoxProductos";
            this.groupBoxProductos.Size = new System.Drawing.Size(650, 380);
            this.groupBoxProductos.TabIndex = 3;
            this.groupBoxProductos.TabStop = false;
            this.groupBoxProductos.Text = "Productos";
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminarProducto.Location = new System.Drawing.Point(520, 75);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarProducto.TabIndex = 8;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.Location = new System.Drawing.Point(520, 35);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarProducto.TabIndex = 7;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(390, 38);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 25);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(230, 38);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 25);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArticulo.Location = new System.Drawing.Point(30, 38);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(150, 25);
            this.txtArticulo.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidad.Location = new System.Drawing.Point(390, 20);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 15);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecio.Location = new System.Drawing.Point(230, 20);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 15);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArticulo.Location = new System.Drawing.Point(30, 20);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(50, 15);
            this.lblArticulo.TabIndex = 1;
            this.lblArticulo.Text = "Artículo";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 120);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(590, 240);
            this.dgvProductos.TabIndex = 0;
            // 
            // groupBoxTotales
            // 
            this.groupBoxTotales.Controls.Add(this.lblTotalValor);
            this.groupBoxTotales.Controls.Add(this.lblIvaValor);
            this.groupBoxTotales.Controls.Add(this.lblSubtotalValor);
            this.groupBoxTotales.Controls.Add(this.lblTotal);
            this.groupBoxTotales.Controls.Add(this.lblIva);
            this.groupBoxTotales.Controls.Add(this.lblSubtotal);
            this.groupBoxTotales.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTotales.Location = new System.Drawing.Point(690, 280);
            this.groupBoxTotales.Name = "groupBoxTotales";
            this.groupBoxTotales.Size = new System.Drawing.Size(210, 180);
            this.groupBoxTotales.TabIndex = 4;
            this.groupBoxTotales.TabStop = false;
            this.groupBoxTotales.Text = "Resumen";
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalValor.Location = new System.Drawing.Point(20, 135);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(62, 25);
            this.lblTotalValor.TabIndex = 5;
            this.lblTotalValor.Text = "₡0.00";
            // 
            // lblIvaValor
            // 
            this.lblIvaValor.AutoSize = true;
            this.lblIvaValor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIvaValor.Location = new System.Drawing.Point(20, 90);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(46, 20);
            this.lblIvaValor.TabIndex = 4;
            this.lblIvaValor.Text = "₡0.00";
            // 
            // lblSubtotalValor
            // 
            this.lblSubtotalValor.AutoSize = true;
            this.lblSubtotalValor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtotalValor.Location = new System.Drawing.Point(20, 45);
            this.lblSubtotalValor.Name = "lblSubtotalValor";
            this.lblSubtotalValor.Size = new System.Drawing.Size(46, 20);
            this.lblSubtotalValor.TabIndex = 3;
            this.lblSubtotalValor.Text = "₡0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 110);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 21);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "TOTAL";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIva.Location = new System.Drawing.Point(20, 70);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(73, 19);
            this.lblIva.TabIndex = 1;
            this.lblIva.Text = "IVA (13%)";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotal.Location = new System.Drawing.Point(20, 25);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(63, 19);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // btnGuardarFactura
            // 
            this.btnGuardarFactura.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardarFactura.Location = new System.Drawing.Point(690, 480);
            this.btnGuardarFactura.Name = "btnGuardarFactura";
            this.btnGuardarFactura.Size = new System.Drawing.Size(210, 45);
            this.btnGuardarFactura.TabIndex = 5;
            this.btnGuardarFactura.Text = "Guardar Factura";
            this.btnGuardarFactura.UseVisualStyleBackColor = true;
            this.btnGuardarFactura.Click += new System.EventHandler(this.btnGuardarFactura_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.Location = new System.Drawing.Point(690, 540);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(210, 40);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVolverMenu.Location = new System.Drawing.Point(690, 600);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(210, 40);
            this.btnVolverMenu.TabIndex = 7;
            this.btnVolverMenu.Text = "Volver al Menú";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // FormFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 680);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardarFactura);
            this.Controls.Add(this.groupBoxTotales);
            this.Controls.Add(this.groupBoxProductos);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.lblNumeroFactura);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturación - Tienda La Esquina";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFacturas_FormClosing);
            this.Load += new System.EventHandler(this.FormFacturas_Load);
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            this.groupBoxProductos.ResumeLayout(false);
            this.groupBoxProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBoxTotales.ResumeLayout(false);
            this.groupBoxTotales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.TextBox txtDireccionCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox groupBoxProductos;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox groupBoxTotales;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblIvaValor;
        private System.Windows.Forms.Label lblSubtotalValor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnGuardarFactura;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolverMenu;
    }
}
