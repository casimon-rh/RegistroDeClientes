using Data.Interfaz;
using Extra.Plain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroDeClientesBD.Logic
{
    public class LogicClientes : ICatalogos<Cliente>
    {
        public IDaoCrud<Cliente> dao { get; set; }
        public void inserta(Cliente aux)
        {
            try
            {
                dao.inserta(aux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> getAll()
        {
            try
            {
                return dao.consulta();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void borrar(Cliente aux)
        {
            try
            {
                dao.borra(aux);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void update()
        {

            try
            {
                dao.commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void refresh()
        {
            try
            {
                dao.getContexto().Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
