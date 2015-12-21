using Secure;
using Secure.Crypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Secure.CadenaConexionVariable
{
    public class SwitchCadenaConexiones : IManejaCadenaConexion
    {
        public IDictionary<string, CadenaConexion> XMLCadenaConexion { get; private set; }
        public CadenaConexion Current { get; set; }

        public ICodifica<StreamReader> descodifica { get; set; }

        private String file;

        public String Archivo
        {
            get { return file; }
            set
            {
                file = value;
                if (file != null)
                {
                    try
                    {
                        if (File.Exists(file))
                        {

                            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(IDictionary<string, CadenaConexion>));
                            System.IO.StreamReader xmlReader = new System.IO.StreamReader(value);
                            String decodificado = descodifica.decode(xmlReader);
                            using (TextReader textReader = new StringReader(decodificado))
                                XMLCadenaConexion = (IDictionary<string, CadenaConexion>)reader.Deserialize(textReader);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        public string getCadenaConexion(string cadena)
        {
            return XMLCadenaConexion[cadena].cadenaConexion;
        }
    }
}
