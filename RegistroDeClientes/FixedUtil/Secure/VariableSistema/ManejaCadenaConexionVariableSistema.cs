
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure.VariableSistema
{
    public class ManejaCadenaConexionVariableSistema : IManejaCadenaConexion
    {
        public String getCadenaConexion(String cadena)
        {
            return manejaCadena(cadena);
        }
        private String manejaCadena(String cadenaConexion)
        {
            int i = 0;
            String resultado = cadenaConexion;
            String variable = null;
            String auxVariable = null;
            for (i = 0; i < cadenaConexion.Length; i++)
            {
                char aux = cadenaConexion[i];
                if (aux == '$')
                {
                    variable = "";
                    auxVariable = "${";
                    if (cadenaConexion[++i] == '{')
                    {
                        while (aux != '}' && i < cadenaConexion.Length)
                        {
                            aux = cadenaConexion[i++];
                            if (aux != '{' && aux != '}')variable += aux;
                        }
                        auxVariable = "${" + variable + '}';
                        if (!String.IsNullOrEmpty(variable))
                        {
                            String enviroment = Environment.GetEnvironmentVariable(variable);
                            resultado = resultado.Replace(auxVariable, enviroment == null ? "SN" : enviroment);
                        }
                    }
                }
            }
            return resultado;
        }
    }
}
