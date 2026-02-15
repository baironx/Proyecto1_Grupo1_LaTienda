using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLaEsquina
{
    /// <summary>
    /// Representa una factura del sistema
    /// </summary>
    public class Factura
    {
        #region Constantes
        public const decimal PORCENTAJE_IVA = 0.13m; // 13% de IVA
        #endregion

        #region Propiedades
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        #endregion

        #region Propiedades Calculadas
        /// <summary>
        /// Calcula el subtotal de la factura (suma de todos los productos)
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                if (Productos == null || Productos.Count == 0)
                    return 0;

                return Productos.Sum(p => p.Total);
            }
        }

        /// <summary>
        /// Calcula el IVA (13% del subtotal)
        /// </summary>
        public decimal IVA
        {
            get { return Subtotal * PORCENTAJE_IVA; }
        }

        /// <summary>
        /// Calcula el total de la factura (Subtotal + IVA)
        /// </summary>
        public decimal Total
        {
            get { return Subtotal + IVA; }
        }
        #endregion

        #region Constructor
        public Factura()
        {
            Productos = new List<Producto>();
            Fecha = DateTime.Now;
        }

        public Factura(int numeroFactura, Cliente cliente)
        {
            NumeroFactura = numeroFactura;
            Cliente = cliente;
            Productos = new List<Producto>();
            Fecha = DateTime.Now;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Agrega un producto a la factura
        /// </summary>
        public void AgregarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo");

            Productos.Add(producto);
        }

        /// <summary>
        /// Elimina un producto de la factura por su índice
        /// </summary>
        public bool EliminarProducto(int indice)
        {
            if (indice < 0 || indice >= Productos.Count)
                return false;

            Productos.RemoveAt(indice);
            return true;
        }

        /// <summary>
        /// Limpia todos los productos de la factura
        /// </summary>
        public void LimpiarProductos()
        {
            Productos.Clear();
        }

        /// <summary>
        /// Valida que la factura tenga un cliente y al menos un producto
        /// </summary>
        public static string ValidarFactura(Cliente cliente, List<Producto> productos)
        {
            if (cliente == null)
                return "Debe seleccionar un cliente para la factura";

            if (productos == null || productos.Count == 0)
                return "Debe agregar al menos un producto a la factura";

            return string.Empty; // Sin errores
        }
        #endregion

        #region Sobrescritura de métodos
        public override string ToString()
        {
            return $"Factura #{NumeroFactura} - {Fecha:dd/MM/yyyy} - {Cliente?.Nombre} - Total: ₡{Total:N2}";
        }
        #endregion
    }
}
