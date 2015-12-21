using Data.Interfaz;
using Data.Linq.Mapping.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.ADO
{
    public class CrudUsuario : IDaoCrud<Usuario>
    {
        public SeguridadDatabase BD { get; set; }

        public List<Usuario> consulta()
        {
            throw new NotImplementedException();
        }

        public void inserta(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void inserta(List<Usuario> lista)
        {
            throw new NotImplementedException();
        }

        public void modifica(Usuario obj)
        {
            ISQLDataAcces access = new SqlDataAccessTransaction(BD);
            access.CadenaConexion = BD.Connection.ConnectionString;
            try
            {
                access.ExecuteNonQuery(System.Data.CommandType.Text, "update Usuario set bloqueo=1 where id_usuario= '" + obj.idusuario+ "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void borra(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void borraTodo()
        {
            throw new NotImplementedException();
        }

        public void commit()
        {
            throw new NotImplementedException();
        }

        public void restartConnection(string cn)
        {
            throw new NotImplementedException();
        }

        public IContexto getContexto()
        {
            throw new NotImplementedException();
        }
    }
}
