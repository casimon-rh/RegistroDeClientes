using Secure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Binary
{
    [Serializable]
    public class SimpleBinaryDataBase<T>:BinaryDataBase
    {
        public SimpleBinaryDataBase() : base() { }
        public SimpleBinaryDataBase(CadenaConexion cadena) : base(cadena) { }

        private List<T> _Objetos;

        
        public T[] _ObjetosRows
        {
            get { return Objetos.ToArray(); }
            set { if (value != null) Objetos = new List<T>(value); }
        }

        
        public List<T> Objetos
        {
            get { return _Objetos ?? new List<T>(); }
            set { _Objetos = value; }
        }
    }
}
