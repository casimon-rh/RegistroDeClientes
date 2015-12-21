using Data.XML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Visualize.Controles.ComboBox
{
    public class ListaComunItem
    {
        private static ListasComunes lista;
        #region Singleton Members
        public static ListasComunes getInstanceListaCombos(string conexion)
        {
            if (lista == null)
                lista = new ListasComunes(conexion);
            return lista;
        }
        #endregion
    }


    public class ListasComunes
    {
        private List<ItemPersonalizado> _cedentes;
        private List<ItemPersonalizado> _divisa;
        private List<ItemPersonalizado> _cedidos;
        public List<ItemPersonalizado> divisa { get { return _divisa; } }
        public List<ItemPersonalizado> cedentes { get { return _cedentes; } }
        public List<ItemPersonalizado> cedidos { get { return _cedidos; } }

        public ListasComunes(string conexion)
        {
            this.getListas(conexion);
        }


        private List<ItemPersonalizado> getCedido(string conexion)
        {

            Data.ADO.SQLDataAcces bd = new Data.ADO.SQLDataAcces();
            DataSet dataset;
            bd.CadenaConexion = conexion;
            dataset = bd.GetDataSet(CommandType.StoredProcedure, "Cobranza.SpCargaDeudoresFCR");

            if (dataset != null)
                return ItemPersonalizado.getLista(dataset);
            else
                throw new Exception("La consulta Cobranza.SpCargaDeudoresFCR devolvio NULL");
        }


        private List<ItemPersonalizado> getCedentes(string conexion)
        {
            try
            {
                Data.ADO.SQLDataAcces bd = new Data.ADO.SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                List<ItemPersonalizado> lista;
                dataset = bd.GetDataSet(CommandType.StoredProcedure, "CARGA_CLIENTE");

                if (dataset != null)
                    return ItemPersonalizado.getLista(dataset);
                else
                    throw new Exception("La consulta CARGA_CLIENTE devolvio NULL");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ItemPersonalizado> getDivisa(string conexion)
        {

            List<Campo> valores = new List<Campo>();
            List<Campo> texto = new List<Campo>();
            List<ItemPersonalizado> lista;
            Data.ADO.SQLDataAcces bd = new Data.ADO.SQLDataAcces();
            DataSet dataset;
            bd.CadenaConexion = conexion;
            dataset = bd.GetDataSet(CommandType.StoredProcedure, "efactor.carga_Divisa");
            valores.Add(new Campo("DI_DIVISA"));
            texto.Add(new Campo("DI_DIVISA"));
            if (dataset != null)
            {
                lista = ItemPersonalizado.getLista(dataset, valores, texto);
                return lista;

            }
            else
                throw new Exception("");


        }

        public void getListas(string conexion)
        {
            try
            {
                _divisa = getDivisa(conexion);
                _cedentes = getCedentes(conexion);
                _cedidos = getCedido(conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
