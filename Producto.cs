using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLaEsquina
{
    /// <summary>
    /// Representa un producto o artículo para facturación
    /// </summary>
    public class Producto
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        #endregion

        #region Propiedades Calculadas
        /// <summary>
        /// Calcula el total del producto (Precio * Cantidad)
        /// </summary>
        public decimal Total
        {
            get { return Precio * Cantidad; }
        }
        #endregion

        #region Constructor
        public Producto()
        {
            Cantidad = 1; // Por defecto 1 unidad
        }

        public Producto(int id, string nombre, decimal precio, int cantidad)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
        #endregion

        #region Métodos de Validación
        /// <summary>
        /// Valida que todos los campos del producto sean válidos
        /// </summary>
        public static string ValidarProducto(string nombre, string precioTexto, string cantidadTexto)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del producto es obligatorio";

            if (string.IsNullOrWhiteSpace(precioTexto))
                return "El precio del producto es obligatorio";

            if (string.IsNullOrWhiteSpace(cantidadTexto))
                return "La cantidad del producto es obligatoria";

            // Validar que el precio sea un número válido
            if (!decimal.TryParse(precioTexto, out decimal precio))
                return "El precio debe ser un número válido";

            if (precio <= 0)
                return "El precio debe ser mayor a cero";

            // Validar que la cantidad sea un número entero válido
            if (!int.TryParse(cantidadTexto, out int cantidad))
                return "La cantidad debe ser un número entero válido";

            if (cantidad <= 0)
                return "La cantidad debe ser mayor a cero";

            return string.Empty; // Sin errores
        }

        /// <summary>
        /// Valida que un texto sea un número decimal válido
        /// </summary>
        public static bool ValidarPrecio(string precio)
        {
            return decimal.TryParse(precio, out decimal resultado) && resultado > 0;
        }

        /// <summary>
        /// Valida que un texto sea un número entero válido
        /// </summary>
        public static bool ValidarCantidad(string cantidad)
        {
            return int.TryParse(cantidad, out int resultado) && resultado > 0;
        }
        #endregion

        #region Sobrescritura de métodos
        public override string ToString()
        {
            return $"{Nombre} - ₡{Precio:N2} x {Cantidad} = ₡{Total:N2}";
        }
        #endregion
    }
}
