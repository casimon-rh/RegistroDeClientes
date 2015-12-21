using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Configure.Empresa;

namespace Data.Interfaz
{
    /// <summary>
    /// Interface de implementación DAO para las operaciones del módulo de Adquisición de Cartera
    /// </summary>
    public interface IDaoAdquisicion
    {
        void getDireccionEmpresa(string conexion, string id, string tipo);
        clsEmpresa cargaDatos(string idEmpresa, string conexion);
    }
}
