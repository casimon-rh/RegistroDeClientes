using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Secure;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using Extra;

namespace Data.JSON
{
    [DataContract]
    public class JSONDataBase : IContexto
    {
        private string ruta;
        private string strJSON;

        public string Ruta
        {
            get{return ruta;}
            set
            {
                ruta = value;
                try
                {
                    var JSONtext = File.ReadAllText(ruta);
                    strJSON = JSONtext;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JSONDataBase() { }
        public JSONDataBase(CadenaConexion cn)
        {
            try
            {
                IDictionary<string, object> content;
                content = new Dictionary<string, object>();
                Ruta = cn.cadenaConexion;
                if (String.IsNullOrEmpty(strJSON))
                {
                    commitTransaction();
                    Ruta = cn.cadenaConexion;
                }
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(this.GetType());
                System.IO.FileStream sw = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.Read);
                var retorno = dcjs.ReadObject(sw);
                sw.Close();
                foreach (var r in retorno.GetAllProperties().Where(x => x.PropertyType.IsGenericType).ToList())
                {
                    content.Add(r.Name, retorno.GetPropertyValue(r.Name));
                }
                inicializarTablas(content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void beginTransaction() { }

        public void commitTransaction()
        {
            try
            {
                System.IO.FileStream sw = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write, FileShare.None);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
                
                ser.WriteObject(sw, this);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DbConnection getConexion() { return null; }

        public void Refresh() { }

        public IContexto reload(string cn)
        {
            Ruta = cn;
            return this;
        }

        public void rollbackTransaction() { }


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
