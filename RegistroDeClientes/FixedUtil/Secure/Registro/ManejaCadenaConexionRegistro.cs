using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure.Registro
{
    public class ManejaCadenaConexionRegistro : IManejaCadenaConexion
    {
        private RegistryKey registro;
        private String _raiz;
        public String raiz
        {
            get { return _raiz; }
            set
            {
                registro = Registry.CurrentUser;
                registro = registro.OpenSubKey(value);
                this._raiz = value;
            }
        }

        public string getCadenaConexion(string cadena)
        {
            if (registro != null)
            {
                var a = registro.GetValue(cadena);
                if (a == null) throw new Exception("La clave no se encontró en el registro");
                else
                    return a.ToString();
            }
            else throw new Exception("Registro es NULL");
        }
    }
}
