namespace TiendaLaEsquina
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Opcional: Inicializar datos de prueba
            // Core.GestorDatos.InicializarDatosPrueba();

            Application.Run(new Forms.FormLogin());
        }
    }
}