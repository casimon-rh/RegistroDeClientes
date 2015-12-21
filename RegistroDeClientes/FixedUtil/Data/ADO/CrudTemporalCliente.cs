using Data.ADO;
using Data.Interfaz;
using Data.Linq.Mapping.ComunInfo100;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ADO
{
    public class CrudTemporalCliente : IDaoCrud<TmpUltimoCliente>
    {

        public ComunInfo100BD BD;



        public List<TmpUltimoCliente> consulta()
        {
            throw new NotImplementedException();
        }

        public void inserta(TmpUltimoCliente obj)
        {
            throw new NotImplementedException();
        }

        public void inserta(List<TmpUltimoCliente> lista)
        {
            throw new NotImplementedException();
        }

        public void modifica(TmpUltimoCliente obj)
        {
            ISQLDataAcces access = new SqlDataAccessTransaction(BD);
            try
            {
                access.ExecuteNonQuery(System.Data.CommandType.Text, "update TmpUltimoCliente set  numCliente='" + obj.numCliente + "' where idTipo= '" + obj.idTipo + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void borra(TmpUltimoCliente obj)
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

        public IContexto getContexto()
        {
            return BD;
        }
    }
}
