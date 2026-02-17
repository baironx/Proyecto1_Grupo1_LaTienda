using System;
using System.Windows.Forms;

namespace TiendaLaEsquina.Forms
{
    public partial class FormLogin : Form
    {
        // Credenciales fijas
        private const string USUARIO_VALIDO = "admin";
        private const string PASSWORD_VALIDO = "1234";

        public FormLogin()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configuración inicial del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btnIngresar; // Enter ejecuta el botón Ingresar
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Configurar máscara de contraseña
            txtPassword.PasswordChar = '*';
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Poner foco en el campo de usuario al cargar
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Por favor, ingrese un usuario.", "Campo Requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor, ingrese una contraseña.", "Campo Requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Validar credenciales
                if (txtUsuario.Text == USUARIO_VALIDO && txtPassword.Text == PASSWORD_VALIDO)
                {
                    // Credenciales correctas
                    MessageBox.Show("¡Bienvenido a Tienda La Esquina!", "Acceso Concedido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el menú principal
                    FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
                    menuPrincipal.Show();
                    this.Hide(); // Ocultar el login
                }
                else
                {
                    // Credenciales incorrectas
                    MessageBox.Show("Usuario o contraseña incorrectos.\n\nIntente nuevamente.",
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Limpiar campos y poner foco
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar ingresar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Confirmar antes de salir
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter en el campo de password también ejecuta el login
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.Handled = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
