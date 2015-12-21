using Data.Interfaz;
using Data.Interfaz.Reportes;
using Notify.NotificacionesGUI;
using Secure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Visualize.Ventanas.Reportes;
using Extra;
using System.Xml.Serialization;
using Data.XML;


namespace Data.ADO.Reporting
{
    public class ReportingADO : IReporting<DataRow>
    {
        private SQLDataAcces ADO;
        private string SPName;
        public IDictionary<String, DataTable> RSources;
        private IDictionary<String, DataTable> RRsources;
        public NotificaGUICrystal Handler { get; set; }


        public ReportingADO(CadenaConexion Cn)
        {
            ADO = new SQLDataAcces();
            ADO.CadenaConexion = Cn.cadenaConexion;
        }
        public ReportingADO(CadenaConexion Cn, string s)
        {
            ADO = new SQLDataAcces();
            ADO.CadenaConexion = Cn.cadenaConexion;
        }
        public INotificaGUI getHandler()
        {
            return this.Handler;
        }

        public List<DataRow> getSource()
        {
            this.ADO.ListaParametros.Clear();
            foreach (string key in RSources.Keys)
            {
                Log.Log.logdebug("Ejecucion del sp:" + key);
                RSources[key] = this.ADO.GetDataSet(CommandType.StoredProcedure, key).Tables[0];
            }
            return null;
        }
        public List<DataRow> getSource(IDictionary<string, IDictionary<string, string>> parametros = null)
        {
            RRsources = new Dictionary<string, DataTable>();
            foreach (var a in RSources.Keys)
            {
                RRsources.Add(a, null);
            }
            foreach (string key in (RSources ?? new Dictionary<string, DataTable>()).Keys)
            {
                foreach (IDictionary<string, string> k in (from p in parametros ?? (new Dictionary<string, IDictionary<string, string>>()) where p.Key == key select p.Value).ToList())
                {
                    this.ADO.ListaParametros.Clear();
                    foreach (string kk in k.Keys)
                    {
                        Log.Log.logdebug("Parametro del sp " + key + ":[" + kk + "," + k[kk] + "]");
                        this.ADO.ListaParametros.Add(new SQLDataAcces.Parametro(kk, k[kk]));
                    }
                }
                Log.Log.logdebug("Ejecucion del sp:" + key);
                RRsources[key] = this.ADO.GetDataSet(CommandType.StoredProcedure, key).Tables[0];
                RSources = RRsources;
            }
            return null;
        }
        public IDictionary<string, T> getSourceAsync<T>(IDictionary<string, IDictionary<string, string>> parametros = null)
        {
            RRsources = new Dictionary<string, DataTable>();
            foreach (var a in RSources.Keys)
                RRsources.Add(a, null);

            foreach (string key in (RSources ?? new Dictionary<string, DataTable>()).Keys)
            {
                foreach (IDictionary<string, string> k in (from p in parametros ?? (new Dictionary<string, IDictionary<string, string>>()) where p.Key == key select p.Value).ToList())
                {
                    this.ADO.ListaParametros.Clear();
                    foreach (string kk in k.Keys)
                    {
                        Log.Log.logdebug("Parametro del sp " + key + ":[" + kk + "," + k[kk] + "]");
                        this.ADO.ListaParametros.Add(new SQLDataAcces.Parametro(kk, k[kk]));

                    }
                }
                Log.Log.logdebug("Ejecucion del sp:" + key);
                RRsources[key] = this.ADO.GetDataSet(CommandType.StoredProcedure, key).Tables[0];
                Log.Log.logdebug("Datos:");
                Log.Log.logdebug((RRsources[key]).SerializeObject(new System.IO.StringWriter()));
                RSources = RRsources;
            }

            if ((from t in RRsources select t.Value.Rows.Count).Sum() == 0 && !Handler.SinDAO)
                throw new Exception("No existen datos");
            return RRsources as IDictionary<string, T>;
        }


        public void ToReport(IDictionary<string, IDictionary<string, string>> parametros = null, bool async = false, Visor.Delegado Controller = null)
        {
            if (async)
                if (!Handler.SinDAO)
                    Visor.NotificaAsyncro<DataRow, DataTable>(getSourceAsync<DataTable>, this.Handler.Process, this.Handler, (this as IReporting<DataRow>), this.RSources, parametros, Controller);
                else
                    Visor.NotificaAsyncro<DataRow, DataTable>(getSourceAsync<DataTable>, this.Handler.Process, this.Handler, (this as IReporting<DataRow>), this.RSources, ADO.CadenaConexion, parametros, Controller);
            else
            {
                var unused = getSource(parametros);
                this.Handler.ReportSources = RRsources;
                if ((from t in RRsources select t.Value.Rows.Count).Sum() == 0)
                    this.Handler.notificaVacio();
                else
                    this.Handler.notificar();
            }
        }


        public void setRSource<TT>(IDictionary<string, TT> s)
        {
            this.RSources = this.RRsources = s as IDictionary<String, DataTable>;
        }


        public IDictionary<string, T> ToReport<T>(IDictionary<string, IDictionary<string, string>> parametros = null, bool async = false, Visor.Delegado Controller = null)
        {
            throw new NotImplementedException();
        }


        public IDictionary<string, TT> getSourceAsync<TT>(IDictionary<string, IDictionary<string, string>> parametros = null, bool async = false)
        {
            throw new NotImplementedException();
        }


        public void SetConnections(INotificaGUI handler)
        {
            if (handler is NotificaGUICrystal)
            {
                NotificaGUICrystal h = Handler as NotificaGUICrystal;
                if (h.SinDAO)
                {
                    foreach (CrystalDecisions.Shared.IConnectionInfo con in h.RptDoc.DataSourceConnections)
                    {
                        con.SetConnection(ADO.CadenaConexion, ADO.CadenaConexion, false);
                        con.SetLogon(ADO.CadenaConexion, ADO.CadenaConexion);
                    }
                }
            }
        }
    }
}
