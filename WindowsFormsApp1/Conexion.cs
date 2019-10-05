using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Conexion
    {
        public string connectionString = "DATA SOURCE = ORCL; PASSWORD=pampam; USER ID=system;";
        public void RunOracleTransaction(List<string> queries)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                OracleTransaction transaction;

                // Start a local transaction
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                command.Transaction = transaction;

                try
                {
                    foreach(string query in queries)
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();

                    }
                    transaction.Commit();
                    Console.WriteLine("Correcto");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("error que provoca rollback");
                }
            }
        }
    }
}
