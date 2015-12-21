using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.XML
{
    public class SimpleDAOCRUDXML<T> : IDaoCrudLinq<T, SimpleXMLDatabase<T>>
    {
        public SimpleDAOCRUDXML()
        {

        }

        public override List<T> consulta()
        {
            try
            {
                lock (BD)
                        return BD.getLista<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override void inserta(T obj)
        {
            try
            {
                lock (BD)
                    BD.getLista<T>().Add(obj);
                commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void inserta(List<T> lista)
        {
            try
            {
                lock (BD)
                    BD.setLista(lista);
                commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void modifica(T obj)
        {
            try
            {
                lock (BD)
                    for (int i = 0; i < BD.getLista<T>().Count(); i++)
                    {
                        var aux = BD.getLista<T>()[i];
                        if (aux.Equals(obj))
                            aux = obj;
                    }
                commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override void borra(T obj)
        {
            try
            {
                lock (BD)
                {
                    BD.getLista<T>().Remove(obj);
                }

                commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void borraTodo()
        {
            try
            {
                lock (BD)
                    BD.setLista(new List<T>());
                commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void commit()
        {
            try
            {
                lock (BD)
                    BD.commitTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
