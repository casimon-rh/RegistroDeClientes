using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure
{
    public interface ISeguridad
    {
        void cargaConfiguracionDeNegocio(string conexionFactor, DateTime fecha);
        void CargaVariablesSistema();
        bool compruebaVinculacion(string modulo, string version);
        void creaVinculacion(string version, string modulo);
        string getVersion();
        void vinculaVariablesSistema();
        string getNombreModulo();
    }
}
