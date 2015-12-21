using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    public interface IContexto
    {
        void beginTransaction();
        void commitTransaction();
        void rollbackTransaction();
        DbConnection getConexion();
        void Refresh();



    }
}
