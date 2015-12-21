using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaz
{
    public interface ICatalogos<T>
    {
        void borrar(T aux);
        System.Collections.Generic.List<T> getAll();
        void inserta(T aux);
        void update();
        void refresh();
    }
}
