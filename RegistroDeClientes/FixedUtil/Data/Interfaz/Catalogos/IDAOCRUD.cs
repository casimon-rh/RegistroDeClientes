using Data.XML.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    public interface IDaoCrud<T>
    {
        List<T> consulta();
        void inserta(T obj);
        void inserta(List<T> lista);
        void modifica(T obj);
        void borra(T obj);
        void borraTodo();
        void commit();
        void restartConnection(string cn);
        IContexto getContexto();
    }
    public abstract class IDaoCrudLinq<T, P> : IDaoCrud<T> where P : IContexto
    {
        private List<Errores<T>> _errores;
        public List<Errores<T>> Errores
        {
            get { return _errores; }
            set { _errores = value; }
        }
        private P _BD;
        public P BD
        {
            get { return _BD; }
            set { _BD = value; }
        }
        public abstract List<T> consulta();
        public abstract void inserta(T obj);
        public abstract void inserta(List<T> lista);
        public abstract void modifica(T obj);
        public abstract void borra(T obj);
        public abstract void borraTodo();
        public abstract void commit();
        public IContexto getContexto()
        {
            return BD;
        }


        public void restartConnection(string cn)
        {
            BD =(P) BD.reload(cn) ;
        }
    }
}
    
