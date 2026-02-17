using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaLaEsquina.Core
{
    /// <summary>
    /// Representa un cliente del sistema
    /// </summary>
    public class Cliente
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        #endregion

        #region Constructor
        public Cliente()
        {
            Activo = true; // Por defecto los clientes están activos
        }

        public Cliente(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Activo = true;
        }
        #endregion

        #region Métodos de Validación
        /// <summary>
        /// Valida que todos los campos del cliente estén completos
        /// </summary>
        public static string ValidarCampos(string nombre, string direccion, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del cliente es obligatorio";

            if (string.IsNullOrWhiteSpace(direccion))
                return "La dirección del cliente es obligatoria";

            if (string.IsNullOrWhiteSpace(telefono))
                return "El teléfono del cliente es obligatorio";

            return string.Empty; // Sin errores
        }

        /// <summary>
        /// Valida que el teléfono contenga solo números
        /// </summary>
        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Verificar que solo contenga dígitos, espacios o guiones
            return telefono.All(c => char.IsDigit(c) || c == ' ' || c == '-');
        }

        /// <summary>
        /// Valida que el nombre contenga solo letras y espacios
        /// </summary>
        public static bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            return nombre.All(c => char.IsLetter(c) || c == ' ');
        }
        #endregion

        #region Sobrescritura de métodos
        public override string ToString()
        {
            return $"{Nombre} - {Telefono} - {(Activo ? "Activo" : "Inactivo")}";
        }
        #endregion
    }
}
