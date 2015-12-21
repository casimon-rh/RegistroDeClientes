using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Interfaz;
using Data.Linq.Mapping.Factor100;

namespace Data.ADO
{
    public class CrudDetalleTasa : IDaoCrud<CatalogoTasasDetalle>
    {

        public FactorDatabase BD;
        public List<CatalogoTasasDetalle> consulta()
        {
            throw new NotImplementedException();
        }

        public void inserta(CatalogoTasasDetalle obj)
        {
            throw new NotImplementedException();
        }

        public void inserta(List<CatalogoTasasDetalle> lista)
        {
            throw new NotImplementedException();
        }

        public void modifica(CatalogoTasasDetalle obj)
        {
            ISQLDataAcces access = new SqlDataAccessTransaction(BD);
            try
            {
                access.ExecuteNonQuery(System.Data.CommandType.Text, "update CatalogoTasasDetalle set  id_tasa='" + obj.id_tasa + "', plazo_inicial=" + obj.plazo_inicial + ", plazo_final=" + obj.plazo_final + ", spread=" + obj.spread + ", indexada=" + (obj.indexada?1:0) + " where id= '" + obj.id + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void borra(CatalogoTasasDetalle obj)
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
            throw new NotImplementedException();
        }

        List<CatalogoTasasDetalle> IDaoCrud<CatalogoTasasDetalle>.consulta()
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.inserta(CatalogoTasasDetalle obj)
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.inserta(List<CatalogoTasasDetalle> lista)
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.modifica(CatalogoTasasDetalle obj)
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.borra(CatalogoTasasDetalle obj)
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.borraTodo()
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.commit()
        {
            throw new NotImplementedException();
        }

        void IDaoCrud<CatalogoTasasDetalle>.restartConnection(string cn)
        {
            throw new NotImplementedException();
        }

        IContexto IDaoCrud<CatalogoTasasDetalle>.getContexto()
        {
            throw new NotImplementedException();
        }
    }
}
