using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Linq.Mapping.EFactor;
using Notify.Email;

namespace Data.Interfaz
{
    public interface IDaoEfactor
    {
        IEnumerable<CorreoSaliente> getCorreosSaliente();
        CorreoSaliente getCorreoSaliente();
        Correo getCorreoConfigurado();
    }
}
