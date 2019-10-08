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
        public string connectionString = "DATA SOURCE = " + Properties.Settings.Default.nombre_db + "; PASSWORD=" + Properties.Settings.Default.contrasenia_db + "; USER ID=" + Properties.Settings.Default.usuario_db + ";";
        public void RunOracleTransaction(OracleCommand command)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                
                OracleTransaction transaction;

                // Start a local transaction
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                command.Transaction = transaction;

                try
                {                   
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Neither record was written to database.");
                }
                connection.Close();
            }
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
