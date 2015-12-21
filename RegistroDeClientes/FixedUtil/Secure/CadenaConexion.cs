using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Secure
{
    public class CadenaConexion
    {
        private String _cadenaConexion;
        private String valor;
        public bool isXMLSA { get; set; }

        public CadenaConexion() { }

        public CadenaConexion(IManejaCadenaConexion convertidor) { this.convertidor = convertidor; }

        public IManejaCadenaConexion convertidor { set; get; }
        public String value
        {
            set
            {
                valor = value;
                if (convertidor != null)
                    _cadenaConexion = convertidor.getCadenaConexion(value);
                else
                    _cadenaConexion = value;
            }
            get
            {
                return valor;
            }
        }


        public String cadenaConexion
        {
            get
            {
                if (isXMLSA)
                {
                    valor = @"C:\Info100\Rsa.dll.deploy";
                    //Alloy
                    //valor = @"\\10.1.0.122\Info100\Modulos\SistemaAcceso\Application Files\SAWPFCTP_4_3_0_1\Rsa.dll.deploy";

                    //Aquity
                    //valor = @"\\192.168.3.4\Info100\Modulos\SistemaAcceso\Application Files\SAWPFCTP_4_3_0_1\Rsa.dll.deploy";

                    //NextFin
                    //valor = @"\\Sharepoint\Info100\SpringAir\Modulos\SistemaAcceso\Application Files\SAWPFCTP_4_3_0_1\Rsa.dll.deploy";
                    //valor = @"\\192.168.9.246\Info100\Modulos\SistemaAcceso\Application Files\SAWPFCTP_4_3_0_1\Rsa.dll.deploy";

                    _cadenaConexion = valor;
                }
                return _cadenaConexion;
            }
        }

    }
    public class ContenedorCadenasConexion
    {
        public IDictionary<String, CadenaConexion> conexiones { get; set; }

    }
    public static class SharedCadenaConexion
    {
        private static ContenedorCadenasConexion contenedor;
        public static ContenedorCadenasConexion Contexto
        {
            get
            {
                if (contenedor == null)
                {
                    IApplicationContext applicationContext = ContextRegistry.GetContext();
                    contenedor = applicationContext.GetObject("CadenasConexion") as ContenedorCadenasConexion;
                }
                return contenedor;
            }

        }
    }
}

