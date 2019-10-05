using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Conexion
    {
        public static OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=admin; USER ID=system;");

        public static void abrirConexion()
        {
            ora.Close();
            ora.Open();
        }

        public static void cerrarConexion()
        {
            ora.Close();
        }
    }
}
