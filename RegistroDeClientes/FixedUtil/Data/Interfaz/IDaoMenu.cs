using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Linq.Mapping.Seguridad;
namespace Data.Interfaz
{
    public interface IDaoMenu
    {
        bool borraMenuPorModulo(string modulo);
        void insertaMenu(SeguridadMaestra sec);
    }
}
