using System.Data.SqlClient;
using Microsoft.Extensions.Configuration; // Asegúrate de tener esta referencia

namespace BaseDeDatos1.Datos
{
    public class Conexion
    {
        // Variable para almacenar la cadena de conexión
        private string cadenaConexion = string.Empty;

        // Constructor para obtener la cadena de conexión del archivo appsettings.json
        public Conexion()
        {
            // Usamos ConfigurationBuilder para leer la cadena de conexión desde el archivo appsettings.json
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            // Aquí obtenemos el valor de la sección "ConnectionStrings:cadenaConexion"
            cadenaConexion = builder.GetSection("ConnectionStrings:cadenaConexion").Value;

            // Verificación para evitar posibles nulos
            if (string.IsNullOrEmpty(cadenaConexion))
            {
                throw new InvalidOperationException("La cadena de conexión no se encontró o está vacía en appsettings.json.");
            }
        }

        // Método que devuelve la cadena de conexión
        public string GetCadenaConexion()
        {
            return cadenaConexion;
        }
    }
}
