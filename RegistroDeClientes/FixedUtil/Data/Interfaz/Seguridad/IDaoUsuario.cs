using Data.Linq.Mapping.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    public interface IDaoUsuario
    {
        Usuario getUsusario(Int32 id);
    }
}
