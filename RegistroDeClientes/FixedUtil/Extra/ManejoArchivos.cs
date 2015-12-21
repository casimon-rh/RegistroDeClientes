using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra
{
    public class ManejoArchivos
    {
        public static string obtieneExtensionArchivo(string archivo)
        {
            string[] arreglo;
            try
            {
                if (!(String.IsNullOrEmpty(archivo)))
                {
                    arreglo = archivo.Split(".".ToCharArray());
                    return arreglo[arreglo.Length - 1];
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
