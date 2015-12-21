using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Secure.Validador
{

    public class ValidaCadenaConexionSQLServer : IValidaCadenaConexionSQL
    {
        public bool validaConexion(String cadena)
        {
            SqlConnection sql;
            sql = new SqlConnection(cadena);
            try
            {
                sql.Open();
                sql.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
   
}
