using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Secure;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Extra;

namespace Data.Binary
{
    [Serializable]
    public class BinaryDataBase : IContexto
    {
        private string ruta;
        private byte[] bytes;
        public BinaryDataBase() { }
        public BinaryDataBase(CadenaConexion cadena)
        {
            try
            {
                IDictionary<string, object> content;
                content = new Dictionary<string, object>();
                Ruta = cadena.cadenaConexion;
                if (bytes == null || bytes.Length == 0)
                {
                    commitTransaction();
                    Ruta = cadena.cadenaConexion;
                }
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.Read);
                var retorno = formatter.Deserialize(stream);
                stream.Close();
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

        public string Ruta
        {
            get
            {
                return ruta;
            }

            set
            {
                ruta = value;
                try
                {
                    var by = File.ReadAllBytes(ruta);
                    bytes = by;
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

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DbConnection getConexion(){return null;}

        public void Refresh(){}

        public IContexto reload(string cn)
        {
            this.Ruta = cn;
            return this;
        }

        public void rollbackTransaction(){ }

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
