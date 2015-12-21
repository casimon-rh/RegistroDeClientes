using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Configure.Empresa;

namespace Data.Interfaz
{
    public interface IDaoAdquisicion
    {
        void getDireccionEmpresa(string conexion, string id, string tipo);
        clsEmpresa cargaDatos(string idEmpresa, string conexion);
    }
}
