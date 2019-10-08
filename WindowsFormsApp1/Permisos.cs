using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Permisos
    {
        public static bool esDBA(String id_empleado)
        {
            Conexion.abrirConexion();
            OracleCommand comando = new OracleCommand("empleado_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //comando.Parameters.Add("codigo_empleado", OracleType.VarChar).Value = id_empleado;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            foreach (DataRow row in tabla.Rows)
            {
                Console.WriteLine(row[0]);
                if (row[0].ToString().Equals(id_empleado))
                {
                    if (row[5].ToString().Equals("1") || row[5].ToString().Equals("DBA"))
                    {
                        Conexion.cerrarConexion();
                        return true;
                    }
                }
            }

            Conexion.cerrarConexion();
            return false;
        }

        public static bool esCajero(String id_empleado)
        {
            Conexion.abrirConexion();
            OracleCommand comando = new OracleCommand("empleado_select", Conexion.ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //comando.Parameters.Add("codigo_empleado", OracleType.VarChar).Value = id_empleado;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            foreach (DataRow row in tabla.Rows)
            {
                Console.WriteLine(row[0]);
                if (row[0].ToString().Equals(id_empleado))
                {
                    if (row[5].ToString().Equals("3") || row[5].ToString().Equals("CAJERO"))
                    {
                        Conexion.cerrarConexion();
                        return true;
                    }
                }
            }

            Conexion.cerrarConexion();
            return false;
        }
    }
}
