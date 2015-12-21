using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra
{
    public static class ExtensionString
    {
        public static string Right(this string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public static string Left(this string param, int length)
        {

            string result = param.Substring(0, length);
            return result;
        }

        public static string Mid(this string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        public static string Mid(this string param, int startIndex)
        {
            string result = param.Substring(startIndex);
            return result;
        }
        public static string formatoDireccion(this string ruta)
        {
            string[] bloques;
            string salida;
            bloques = ruta.Split('\\');
            salida = "";
            for (int i = 1; i < bloques.Length - 1; i++)
            {
                salida += bloques[i];
                if (i != bloques.Length - 1)
                    salida += '\\';
            }
            return salida;
        }
        public static string quitaDobleDiagonalInvertida(this string ruta)
        {
            string[] bloques;
            string salida;
            bloques = ruta.Split('\\','\\');
            salida = "";
            for (int i = 1; i < bloques.Length - 1; i++)
            {
                salida += bloques[i];
                if (i != bloques.Length - 1)
                    salida += '\\';
            }
            return salida;
        }

    }
}
