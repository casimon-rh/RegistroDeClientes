using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaz.Reportes
{
    public class ContenedorReportes<T>
    {
        public IDictionary<string, IReporting<T>> Reportes { get; set; }
    }
}
