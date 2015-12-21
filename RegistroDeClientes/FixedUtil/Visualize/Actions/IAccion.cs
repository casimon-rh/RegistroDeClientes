using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualize.Actions
{
    public interface IAccion
    {
        void realiza();
        void realiza(string referencia);
        void realiza(object referencia);

    }
}
