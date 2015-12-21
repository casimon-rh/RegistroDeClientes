using Configure;
using Data.ADO;
using Data.Linq.DAO.Seguridad;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure.Registro
{
    public abstract class SeguridadRegistry : ISeguridad
    {
        private SQLDataAcces oBDConnection;
        public abstract string getVersion();
        public abstract bool compruebaVinculacion(string modulo, string version);
        public abstract void creaVinculacion(string version, string modulo);
        public abstract RegistryKey getRaiz();
        public abstract string getNombreModulo();
        public DaoUsuarioLinq UsuarioDaoCurrent = new DaoUsuarioLinq();

        public void cargaManejadorReportes()
        {

            try
            {
                //Carga carga = new Carga();
                //carga.SetDataSource(new DataSet());
                //carga.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "Carga");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void vinculaVariablesSistema()
        {
            try
            {
                CargaVariablesSistema();
                //Cargamos el idioma correspodiente
                cargaParametrosGlobales(Contexto.cnBaseFactor100);
                cargaConfiguracionDeNegocio(Contexto.cnBaseFactor100, Contexto.fechaSistema);
                Contexto.nombreModulo = getNombreModulo();
                //cargaManejadorReportes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargaVariablesSistema()
        {
            string assembly;
            try
            {
                // Obtain the test key (read-only) and display it.
                RegistryKey rkTest = getRaiz();
                Contexto.idUsuario = rkTest.GetValue("cveUsuario").ToString();
                Contexto.nombreEmpresa = rkTest.GetValue("NombreEmpresa").ToString();
                Contexto.idEmpresa = rkTest.GetValue("cveEmpresa").ToString();
                Contexto.cnBaseSeguridad = rkTest.GetValue("CnBaseSeguridad").ToString();
                Contexto.cnBaseFactor100 = rkTest.GetValue("CnBaseFactor").ToString();
                Contexto.cnBaseComunInfo100 = rkTest.GetValue("CnBaseComun").ToString();
                Contexto.idSistema = rkTest.GetValue("CveSistema").ToString();
                Contexto.cnBaseIdioma = rkTest.GetValue("CnBaseIdioma").ToString();
                Contexto.idIdioma = Convert.ToInt32(rkTest.GetValue("Idioma").ToString());
                Contexto.cnBaseEFactor = rkTest.GetValue("CnBaseEFactor").ToString();
                Contexto.nombreUsuario = rkTest.GetValue("Nombre").ToString();
                assembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Contexto.version = getVersion();
                rkTest.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cargaParametrosGlobales(String conexionFactor)
        {
            DataSet dset = new DataSet();
            SQLDataAcces db = new SQLDataAcces();
            db.CadenaConexion = conexionFactor;
            db.ListaParametros.Clear();
            dset = db.GetDataSet(CommandType.StoredProcedure, "[dbo].[CARGA_VARIABLES_DE_AMBIENTE]");
            try
            {
                Contexto.fechaSistema = dset.Tables[0].Rows[0].Field<DateTime>("PS_DATE");/////////////////////////////
                Contexto.PS_EXTERNA = dset.Tables[0].Rows[0].Field<bool>("PS_EXTERNA");
                Contexto.PS_ClAuto = dset.Tables[0].Rows[0].Field<bool>("PS_ClAuto");
                if (dset.Tables[0].Rows[0].Field<String>("PS_FIMSA") == null) { Contexto.PS_FIMSA = ""; } else { Contexto.PS_FIMSA = dset.Tables[0].Rows[0].Field<String>("PS_FIMSA"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_CATER") == null) { Contexto.PS_CATER = ""; } else { Contexto.PS_CATER = dset.Tables[0].Rows[0].Field<String>("PS_CATER"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_BURSA") == null) { Contexto.PS_BURSA = ""; } else { Contexto.PS_BURSA = dset.Tables[0].Rows[0].Field<String>("PS_BURSA"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_MEX") == null) { Contexto.PS_MEX = ""; } else { Contexto.PS_MEX = dset.Tables[0].Rows[0].Field<String>("PS_MEX"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_BANSA") == null) { Contexto.PS_BANSA = ""; } else { Contexto.PS_BANSA = dset.Tables[0].Rows[0].Field<String>("PS_BANSA"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_BANCO") == null) { Contexto.PS_BANCO = ""; } else { Contexto.PS_BANCO = dset.Tables[0].Rows[0].Field<String>("PS_BANCO"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_HOLDI") == null) { Contexto.PS_HOLDI = ""; } else { Contexto.PS_HOLDI = dset.Tables[0].Rows[0].Field<String>("PS_HOLDI"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_CORRE") == null) { Contexto.PS_CORRE = ""; } else { Contexto.PS_CORRE = dset.Tables[0].Rows[0].Field<String>("PS_CORRE"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_CLIEN") == null) { Contexto.PS_CLIEN = ""; } else { Contexto.PS_CLIEN = dset.Tables[0].Rows[0].Field<String>("PS_CLIEN"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_DEUDO") == null) { Contexto.PS_DEUDO = ""; } else { Contexto.PS_DEUDO = dset.Tables[0].Rows[0].Field<String>("PS_DEUDO"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_COLOR") == null) { Contexto.PS_COLOR = ""; } else { Contexto.PS_COLOR = dset.Tables[0].Rows[0].Field<String>("PS_COLOR"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_IVAIN") == null) { Contexto.PS_IVAIN = ""; } else { Contexto.PS_IVAIN = dset.Tables[0].Rows[0].Field<String>("PS_IVAIN"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_IVAMO") == null) { Contexto.PS_IVAMO = ""; } else { Contexto.PS_IVAMO = dset.Tables[0].Rows[0].Field<String>("PS_IVAMO"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_SEGUR") == null) { Contexto.PS_SEGUR = ""; } else { Contexto.PS_SEGUR = dset.Tables[0].Rows[0].Field<String>("PS_SEGUR"); }
                Contexto.PS_HONOR = dset.Tables[0].Rows[0].Field<int>("PS_HONOR");
                if (dset.Tables[0].Rows[0].Field<String>("PS_DIVISA") == null) { Contexto.PS_DIVISA = ""; } else { Contexto.PS_DIVISA = dset.Tables[0].Rows[0].Field<String>("PS_DIVISA"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_MYPE") == null) { Contexto.PS_MYPE = ""; } else { Contexto.PS_MYPE = dset.Tables[0].Rows[0].Field<String>("PS_MYPE"); }
                Contexto.PS_PLAZO = dset.Tables[0].Rows[0].Field<int>("PS_PLAZO");
                if (dset.Tables[0].Rows[0].Field<String>("PS_COMEX") == null) { Contexto.PS_COMEX = ""; } else { Contexto.PS_COMEX = dset.Tables[0].Rows[0].Field<String>("PS_COMEX"); }
                Contexto.PS_FEMIN = dset.Tables[0].Rows[0].Field<DateTime>("PS_FEMIN");
                if (dset.Tables[0].Rows[0].Field<String>("PS_GE") == null) { Contexto.PS_GE = ""; } else { Contexto.PS_GE = dset.Tables[0].Rows[0].Field<String>("PS_GE"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_LINDI") == null) { Contexto.PS_LINDI = ""; } else { Contexto.PS_LINDI = dset.Tables[0].Rows[0].Field<String>("PS_LINDI"); }
                Contexto.PS_LIMCRE = dset.Tables[0].Rows[0].Field<double>("PS_LIMCRE");
                Contexto.PS_PLAZO = dset.Tables[0].Rows[0].Field<int>("PS_PLAZO");
                Contexto.PS_GRADE = dset.Tables[0].Rows[0].Field<int>("PS_GRADE");
                Contexto.PS_GRACL = dset.Tables[0].Rows[0].Field<int>("PS_GRACL");
                Contexto.annoContable = dset.Tables[0].Rows[0].Field<int>("PS_TADOC");
                Contexto.PLAZOVEN = dset.Tables[0].Rows[0].Field<int>("PLAZOVEN");
                if (dset.Tables[0].Rows[0].Field<String>("PS_INTER") == null) { Contexto.PS_INTER = ""; } else { Contexto.PS_INTER = dset.Tables[0].Rows[0].Field<String>("PS_INTER"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_MORA") == null) { Contexto.PS_MORA = ""; } else { Contexto.PS_MORA = dset.Tables[0].Rows[0].Field<String>("PS_MORA"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_SERIE") == null) { Contexto.PS_SERIE = ""; } else { Contexto.PS_SERIE = dset.Tables[0].Rows[0].Field<String>("PS_SERIE"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_IP_BANCOREMOTO") == null) { Contexto.PS_IP_BANCOREMOTO = ""; } else { Contexto.PS_IP_BANCOREMOTO = dset.Tables[0].Rows[0].Field<String>("PS_IP_BANCOREMOTO"); }
                if (dset.Tables[0].Rows[0].Field<String>("PS_PTO_BANCOREMOTO") == null) { Contexto.PS_PTO_BANCOREMOTO = ""; } else { Contexto.PS_PTO_BANCOREMOTO = dset.Tables[0].Rows[0].Field<String>("PS_PTO_BANCOREMOTO"); }
                //if (dset.Tables[0].Rows[0].Field<bool>("PS_DEPOSITO_AUTOMATICO") == false) { Contexto.PS_DEPOSITO_AUTOMATICO = false; } else { Contexto.PS_DEPOSITO_AUTOMATICO = dset.Tables[0].Rows[0].Field<bool>("PS_DEPOSITO_AUTOMATICO"); }
                Contexto.PS_VALIDA_FESTIVOS = dset.Tables[0].Rows[0].Field<bool>("PS_VALIDA_FESTIVOS");
                Contexto.PS_MANEJA_GAR = dset.Tables[0].Rows[0].Field<bool>("PS_MANEJA_GAR");
                //Contexto.financiera = null;// getDatosFinanciera(conexionFactor);
                Contexto.usuario = null;// new DaoUsuarioLinq().getUsusario(Convert.ToInt32(Contexto.idUsuario));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void cargaConfiguracionDeNegocio(string conexionFactor, DateTime fecha)
        {
            try
            {
                DataSet dset;
                SQLDataAcces db = new SQLDataAcces();

                db.CadenaConexion = conexionFactor;

                db.ListaParametros.Clear();
                dset = db.GetDataSet(CommandType.StoredProcedure, "[dbo].[CARGA_CO_OTROS]");
                if (dset == null)
                    throw new Exception("Ocurrió un problema en la consulta de la descripción de los saldos. Consulte con el administrador del sistema.");

                foreach (DataRow row in dset.Tables[0].Rows)
                {
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idComision)
                    {
                        factoraje.configuracion.saldos.configuracionComisiones.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionComisiones.notaCargo = row["OC_NOTACARGO"].ToString();

                    }
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idAforo)
                    {
                        factoraje.configuracion.saldos.configuracionAforo.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionAforo.notaCargo = row["OC_NOTACARGO"].ToString();

                    }
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idBonificacionInteres)
                    {
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionBonificacionIntereses.notaCargo = row["OC_NOTACARGO"].ToString();

                    }
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idReembolsoNoCedido)
                    {
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionIngresosNoCedidos.notaCargo = row["OC_NOTACARGO"].ToString();

                    }
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idInteresMoratorio)
                    {
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresMoratorio.notaCargo = row["OC_NOTACARGO"].ToString();

                    }
                    if (row["OC_NUM"].ToString() == Configuracion.idTipoSaldos.idInteresOrdinario)
                    {
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.identificador = row["OC_NUM"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.descripcion = row["OC_DESC"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.tipo = row["OC_TIPO"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.generaFactura = row["OC_FACTURA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.generaIva = row["OC_IVA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.afeccionGeneral = row["OC_AFEGRAL"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.generaMoratorios = row["OC_MORA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.generaNotificacion = row["OC_NOTA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.divisa = row["DI_DIVISA"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.reservado = row["OC_RESERVADO"].ToString();
                        factoraje.configuracion.saldos.configuracionInteresOrdinario.notaCargo = row["OC_NOTACARGO"].ToString();

                    }

                }

                //dset=new DataSet ();
                db = new SQLDataAcces();
                db.CadenaConexion = conexionFactor;
                //db.ListaParametros.Add(new SQLDataAcces.Parametro("@Fecha", "23/09/2013"));
                db.ListaParametros.Add(new SQLDataAcces.Parametro("@Fecha", Contexto.fechaSistema));
                dset = db.GetDataSet(CommandType.StoredProcedure, "[comun].[Carga_CO_IVA]");

                if (dset == null)
                
                    throw new Exception("Carga Iva: No hay valores para la fecha" + fecha.ToString("dd/MM/yyyy"));
                
                else
                {
                    foreach (DataRow row in dset.Tables[0].Rows)
                    {
                        factoraje.configuracion.saldos.IVAComisiones.valorIVA = Convert.ToDouble(row["IV_IVACO"].ToString());
                        factoraje.configuracion.saldos.IVAMoratorios.valorIVA = Convert.ToDouble(row["IV_IVAMO"].ToString());
                        factoraje.configuracion.saldos.IVAOrdinarios.valorIVA = Convert.ToDouble(row["IV_IVAIN"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
