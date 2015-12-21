using Data.Interfaz;
using Secure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data.ADO
{
    public class ADOBitacora:IBitacora
    {
        private SqlConnection conn;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public ADOBitacora() { }
        public ADOBitacora(CadenaConexion cc)
        {
            Conn = new SqlConnection(cc.cadenaConexion);
            Conn.Open();
        }
        public override void registraBitacora(string tipo_accion, string descripcion)
        {
            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = Conn;
                if (query.Connection.State != ConnectionState.Open)
                    query.Connection.Open();
                query.CommandType = CommandType.StoredProcedure;
                query.CommandText = "[dbo].[SP_INSERTA_BITACORA]";
                query.Parameters.AddWithValue("@UFACTOR", UFACTOR);
                query.Parameters.AddWithValue("@UWINDOWS", UWINDOWS);
                query.Parameters.AddWithValue("@USQL", "");
                query.Parameters.AddWithValue("@IP", IP);
                query.Parameters.AddWithValue("@FECHA", FECHA);
                query.Parameters.AddWithValue("@T_ACCION", tipo_accion);
                query.Parameters.AddWithValue("@IDPROC", id);
                query.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                query.Parameters.AddWithValue("@OUT", "");
                query.CommandTimeout = 0;
                query.ExecuteNonQuery();
                query.Parameters.Clear();
                Conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void refresh(string cn)
        {
            if(Conn!=null)Conn.Close();
            Conn = new SqlConnection(cn);
            Conn.Open();
        }
    }
}
