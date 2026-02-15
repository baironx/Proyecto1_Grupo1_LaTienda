using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLaEsquina;

namespace TiendaLaEsquina
{
    /// <summary>
    /// Clase estática que gestiona todos los datos en memoria del sistema
    /// </summary>
    public static class GestorDatos
    {
        #region Listas Globales (Static)
        // Lista de clientes en memoria
        private static List<Cliente> clientes = new List<Cliente>();

        // Lista de facturas en memoria
        private static List<Factura> facturas = new List<Factura>();

        // Contadores para generar IDs automáticos
        private static int contadorClienteId = 1;
        private static int contadorProductoId = 1;
        private static int contadorFacturaNumero = 1;
        #endregion

        #region Propiedades de Solo Lectura
        /// <summary>
        /// Obtiene la lista de clientes (solo lectura)
        /// </summary>
        public static List<Cliente> Clientes
        {
            get { return clientes; }
        }

        /// <summary>
        /// Obtiene la lista de facturas (solo lectura)
        /// </summary>
        public static List<Factura> Facturas
        {
            get { return facturas; }
        }
        #endregion

        #region Métodos de Gestión de Clientes
        /// <summary>
        /// Agrega un nuevo cliente al sistema
        /// </summary>
        public static bool AgregarCliente(string nombre, string direccion, string telefono, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validar campos
            string errorValidacion = Cliente.ValidarCampos(nombre, direccion, telefono);
            if (!string.IsNullOrEmpty(errorValidacion))
            {
                mensajeError = errorValidacion;
                return false;
            }

            // Validar teléfono
            if (!Cliente.ValidarTelefono(telefono))
            {
                mensajeError = "El teléfono solo puede contener números, espacios y guiones";
                return false;
            }

            // Validar nombre
            if (!Cliente.ValidarNombre(nombre))
            {
                mensajeError = "El nombre solo puede contener letras y espacios";
                return false;
            }

            // Verificar que no exista un cliente con el mismo teléfono
            if (ExisteClientePorTelefono(telefono))
            {
                mensajeError = "Ya existe un cliente registrado con ese número de teléfono";
                return false;
            }

            // Crear y agregar el cliente
            Cliente nuevoCliente = new Cliente
            {
                Id = contadorClienteId++,
                Nombre = nombre.Trim(),
                Direccion = direccion.Trim(),
                Telefono = telefono.Trim(),
                Activo = true
            };

            clientes.Add(nuevoCliente);
            return true;
        }

        /// <summary>
        /// Modifica un cliente existente
        /// </summary>
        public static bool ModificarCliente(int id, string nombre, string direccion, string telefono, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Buscar el cliente
            Cliente cliente = clientes.FirstOrDefault(c => c.Id == id)!;
            if (cliente == null)
            {
                mensajeError = "Cliente no encontrado";
                return false;
            }

            // Validar campos
            string errorValidacion = Cliente.ValidarCampos(nombre, direccion, telefono);
            if (!string.IsNullOrEmpty(errorValidacion))
            {
                mensajeError = errorValidacion;
                return false;
            }

            // Validar teléfono
            if (!Cliente.ValidarTelefono(telefono))
            {
                mensajeError = "El teléfono solo puede contener números, espacios y guiones";
                return false;
            }

            // Validar nombre
            if (!Cliente.ValidarNombre(nombre))
            {
                mensajeError = "El nombre solo puede contener letras y espacios";
                return false;
            }

            // Verificar que no exista otro cliente con el mismo teléfono
            Cliente clienteConMismoTelefono = clientes.FirstOrDefault(c => c.Telefono == telefono && c.Id != id)!;
            if (clienteConMismoTelefono != null)
            {
                mensajeError = "Ya existe otro cliente registrado con ese número de teléfono";
                return false;
            }

            // Actualizar los datos
            cliente.Nombre = nombre.Trim();
            cliente.Direccion = direccion.Trim();
            cliente.Telefono = telefono.Trim();

            return true;
        }

        /// <summary>
        /// Inactiva un cliente (no lo elimina, solo cambia su estado)
        /// </summary>
        public static bool InactivarCliente(int id, out string mensajeError)
        {
            mensajeError = string.Empty;

            Cliente cliente = clientes.FirstOrDefault(c => c.Id == id)!;
            if (cliente == null)
            {
                mensajeError = "Cliente no encontrado";
                return false;
            }

            cliente.Activo = false;
            return true;
        }

        /// <summary>
        /// Activa un cliente previamente inactivado
        /// </summary>
        public static bool ActivarCliente(int id, out string mensajeError)
        {
            mensajeError = string.Empty;

            Cliente cliente = clientes.FirstOrDefault(c => c.Id == id)!;
            if (cliente == null)
            {
                mensajeError = "Cliente no encontrado";
                return false;
            }

            cliente.Activo = true;
            return true;
        }

        /// <summary>
        /// Busca un cliente por su ID
        /// </summary>
        public static Cliente BuscarClientePorId(int id)
        {
            return clientes.FirstOrDefault(c => c.Id == id)!;
        }

        /// <summary>
        /// Busca clientes por nombre (búsqueda parcial)
        /// </summary>
        public static List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return new List<Cliente>(clientes);

            return clientes.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        }

        /// <summary>
        /// Obtiene todos los clientes activos
        /// </summary>
        public static List<Cliente> ObtenerClientesActivos()
        {
            return clientes.Where(c => c.Activo).ToList();
        }

        /// <summary>
        /// Verifica si existe un cliente con el teléfono especificado
        /// </summary>
        private static bool ExisteClientePorTelefono(string telefono)
        {
            return clientes.Any(c => c.Telefono == telefono);
        }
        #endregion

        #region Métodos de Gestión de Facturas
        /// <summary>
        /// Crea una nueva factura
        /// </summary>
        public static Factura CrearFactura(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo");

            Factura nuevaFactura = new Factura
            {
                NumeroFactura = contadorFacturaNumero++,
                Cliente = cliente,
                Fecha = DateTime.Now
            };

            return nuevaFactura;
        }

        /// <summary>
        /// Guarda una factura en el sistema
        /// </summary>
        public static bool GuardarFactura(Factura factura, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validar la factura
            string errorValidacion = Factura.ValidarFactura(factura.Cliente, factura.Productos);
            if (!string.IsNullOrEmpty(errorValidacion))
            {
                mensajeError = errorValidacion;
                return false;
            }

            facturas.Add(factura);
            return true;
        }

        /// <summary>
        /// Obtiene el siguiente ID disponible para un producto
        /// </summary>
        public static int ObtenerSiguienteIdProducto()
        {
            return contadorProductoId++;
        }

        /// <summary>
        /// Obtiene todas las facturas del sistema
        /// </summary>
        public static List<Factura> ObtenerTodasLasFacturas()
        {
            return new List<Factura>(facturas);
        }

        /// <summary>
        /// Busca facturas por número
        /// </summary>
        public static Factura BuscarFacturaPorNumero(int numero)
        {
            return facturas.FirstOrDefault(f => f.NumeroFactura == numero)!;
        }

        /// <summary>
        /// Obtiene las facturas de un cliente específico
        /// </summary>
        public static List<Factura> ObtenerFacturasPorCliente(int clienteId)
        {
            return facturas.Where(f => f.Cliente.Id == clienteId).ToList();
        }
        #endregion

        #region Métodos de Utilidad
        /// <summary>
        /// Limpia todos los datos del sistema (útil para pruebas)
        /// </summary>
        public static void LimpiarTodosDatos()
        {
            clientes.Clear();
            facturas.Clear();
            contadorClienteId = 1;
            contadorProductoId = 1;
            contadorFacturaNumero = 1;
        }

        /// <summary>
        /// Inicializa datos de prueba (opcional, útil para testing)
        /// </summary>
        public static void InicializarDatosPrueba()
        {
            LimpiarTodosDatos();

            // Agregar algunos clientes de prueba
            AgregarCliente("Isaac Perez", "San José, Centro", "88887777", out _);
            AgregarCliente("Nataly Gonzalez", "Heredia, San Francisco", "82828181", out _);
            AgregarCliente("Jery Rodriguez", "Alajuela, Centro", "88889999", out _);
        }
        #endregion
    }
}
