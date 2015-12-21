using Secure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Data.JSON
{
    [DataContract]
    public class SimpleJSONDatabase<T>:JSONDataBase
    {
        public SimpleJSONDatabase() : base() { }
        public SimpleJSONDatabase(CadenaConexion cadena) : base(cadena) { }

        private List<T> _Objetos;


        [DataMember]
        public T[] _ObjetosRows
        {
            get { return Objetos.ToArray(); }
            set { if (value != null) Objetos = new List<T>(value); }
        }

        [DataMember]
        public List<T> Objetos
        {
            get { return _Objetos ?? new List<T>(); }
            set { _Objetos = value; }
        }
    }
}
