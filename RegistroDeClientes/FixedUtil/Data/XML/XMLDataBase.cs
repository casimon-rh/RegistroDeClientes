using Data.Interfaz;
using Secure;
using Secure.Crypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Extra;
using System.Xml.Serialization;
using Extra.Plain;

namespace Data.XML
{
    [XmlInclude(typeof(SimpleXMLDatabase<Cliente>))]
    public abstract class XMLDataBase : IContexto
    {
        public XMLDataBase(CadenaConexion cadena)
        {
            try
            {
                IDictionary<string, object> content;
                content = new Dictionary<string, object>();
                Ruta = cadena.cadenaConexion;
                if (String.IsNullOrEmpty(strXML))
                {
                    commitTransaction();
                    Ruta = cadena.cadenaConexion;
                }
                var retorno = this.deserializeObject(strXML);
                foreach (var r in retorno.GetAllProperties().Where(x => x.PropertyType.IsGenericType).ToList())
                {
                    content.Add(r.Name, retorno.GetPropertyValue(r.Name));
                }
                inicializarTablas(content);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public XMLDataBase() { }

        private String ruta;

        [XmlIgnore]

        private String strXML;
        [XmlIgnore]
        public String Ruta
        {
            get { return ruta; }
            set
            {
                ruta = value;
                try
                {
                    var xmltext = File.ReadAllText(ruta);

                    strXML =  xmltext;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void beginTransaction() { }
        public void commitTransaction()
        {
            StringWriter sw = new StringWriter();
            File.WriteAllText(ruta, (this.SerializeObject(sw)));
            sw.Close();
        }

        public void rollbackTransaction() { }

        public System.Data.Common.DbConnection getConexion()
        {
            return null;
        }

        public void Refresh() { }
        public IContexto reload(string cn)
        {
            throw new NotImplementedException();
        }
        public List<T> getLista<T>()
        {
            try
            {
                return this.GetAllProperties().Where(aux => aux.PropertyType == typeof(List<T>)).FirstOrDefault().GetValue(this, null) as List<T>;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void setLista<T>(List<T> lista)
        {
            try
            {
                this.GetAllProperties().Where(aux => aux.PropertyType == typeof(List<T>)).FirstOrDefault().SetValue(this, lista, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void inicializarTablas(IDictionary<string, object> content)
        {
            foreach (var r in this.GetAllProperties().Where(x => x.PropertyType.IsGenericType).ToList())
            {
                var valor = content[r.Name];
                if (valor != null)
                    r.SetValue(this, valor, null);
            }
        }
    }
}
