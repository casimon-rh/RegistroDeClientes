using Secure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Data.XML
{
    [Serializable]
    
    public class SimpleXMLDatabase<T> : XMLDataBase
    {
        
        public SimpleXMLDatabase() : base() { }
        public SimpleXMLDatabase(CadenaConexion cadena) : base(cadena) { }

        private List<T> _Objetos;

        
        [XmlElement]
        public T[] _ObjetosRows
        {
            get { return Objetos.ToArray(); }
            set { if (value != null) Objetos = new List<T>(value); }
        }

        [XmlIgnore]
        public List<T> Objetos
        {
            get { return _Objetos ?? new List<T>(); }
            set { _Objetos = value; }
        }
    }
}
