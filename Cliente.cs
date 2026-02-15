using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLaEsquina
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
            Activo = true; // Por defecto, el cliente está activo
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

        #region Métodos de validación
        ///  <summary>
        ///  Valida que todos los campos del cliente estén completos
        ///  </summary>

        public static string ValidarCampos(string nombre, string direccion, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del cliente es obligatorio.";
            if (string.IsNullOrWhiteSpace(direccion))
                return "La dirección del cliente es obligatoria.";
            if (string.IsNullOrWhiteSpace(telefono))
                return "El teléfono del cliente es obligatorio.";

            return string.Empty; // No hay errores
        }
        ///  <summary>
        ///  Valida que el teléfono tenga un formato correcto (solo dígitos).
        ///  </summary>
        
        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;
            // Verificar que el teléfono solo contenga dígitos, espacios o guiones.
            return telefono.All(c => char.IsDigit(c) || char.IsWhiteSpace(c) || c == '-');
        }
        ///  <summary>
        ///  Valida que el nombre no contenga caracteres especiales.
        ///  </summary>
        public static bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;
            // Verificar que el nombre solo contenga letras, espacios o guiones.
            return nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-');
        }
        #endregion

        #region Sobrescritura de metodos
        public override string ToString()
        {
            return $"{Nombre} - {Telefono} - {(Activo ? "Activo" : "Inactivo")}";
        }
        #endregion
    }
}