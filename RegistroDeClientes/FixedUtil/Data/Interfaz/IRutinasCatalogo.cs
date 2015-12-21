using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaz
{
    public enum EVENTO
    {
        ALTA, BAJA, UPDATE
    }

    public abstract class IRutinasCatalogos<T>
    {
        public delegate void onError(Exception ex);
        public delegate void onPregunta(String men, EVENTO evento);
        public delegate void onSuccess(String men);
        public delegate void Delete();



        public abstract event onError OnError;
        public abstract event onPregunta OnPregunta;
        public abstract event onSuccess OnSuccess;
        public abstract event Delete Deleted;


        protected T current;
        protected IList<T> catalogos;
        public ICatalogos<T> daoCatalogo;
        public EVENTO evento;

    }
}
