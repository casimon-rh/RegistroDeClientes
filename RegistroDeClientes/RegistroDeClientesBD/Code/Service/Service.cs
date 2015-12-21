using Data.Interfaz;
using Extra.Plain;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroDeClientesBD
{
    public class Service
    {
        private static ICatalogos<Cliente> daoCatalogo;

        public static ICatalogos<Cliente> FuncionDAO()
        {
            try
            {
                if (daoCatalogo == null)
                {
                    IApplicationContext applicationContext = ContextRegistry.GetContext();
                    daoCatalogo = applicationContext.GetObject("Logic") as ICatalogos<Cliente>;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return daoCatalogo;
        }
    }
}
