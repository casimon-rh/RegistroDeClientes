using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure
{
    public abstract class SeguridadFactory
    {
        protected ISeguridad seguridad { get; set; }
        public abstract ISeguridad getSeguridad();
    }
}
