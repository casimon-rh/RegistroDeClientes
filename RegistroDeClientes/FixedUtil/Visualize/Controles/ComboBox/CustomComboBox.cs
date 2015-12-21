using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualize.Controles.ComboBox
{
    public class CustomComboBox :System.Windows.Controls.ComboBox
    {
        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
    }
}
