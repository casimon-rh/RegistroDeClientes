using Data.ADO;
using Data.XML;
using Extra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Visualize.Controles.ComboBox
{
    public static class ManejoComboBox
    {
        public static void cargaCedentes(System.Windows.Controls.ComboBox combo, string conexion)
        {
            try
            {
                DataSet dataset;
                List<ItemPersonalizado> cedentes;
                cedentes = ListaComunItem.getInstanceListaCombos(conexion).cedentes  ;
                if (cedentes != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = cedentes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void cargaCedidos(System.Windows.Controls.ComboBox combo, string conexion)
        {
            try
            {
                DataSet dataset;
                ListasComunes lista;
                List<ItemPersonalizado> cedidos;
                cedidos = ListaComunItem.getInstanceListaCombos(conexion).cedidos ;
                if (cedidos != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = cedidos;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cargaRelacionDivisaCedente(System.Windows.Controls.ComboBox combo, string cedente, string conexion)
        {
            try
            {
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@CL_NUM", cedente));
                dataset = bd.GetDataSet(CommandType.StoredProcedure, "CARGA_RELACION_DIVISA");
                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(combo, dataset);
                else
                    throw new Exception("La consulta CARGA_RELACION_DIVISA devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cargaRelacionDivisaCedido(System.Windows.Controls.ComboBox combo, string cedido, string conexion)
        {
            try
            {
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@TC_NUMERO", cedido));
                dataset = bd.GetDataSet(CommandType.StoredProcedure, "SP_CARGA_DIVISA_DEUDOR");

                valores.Add(new Campo("DI_DIVISA"));
                texto.Add(new Campo("DI_DIVISA"));


                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(combo, dataset, texto, valores);
                else
                    throw new Exception("La consulta SP_CARGA_DIVISA_DEUDOR devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void cargaDivisa(System.Windows.Controls.ComboBox box, string conexion)
        {
            try
            {
                List <ItemPersonalizado> divisas;
                divisas = ListaComunItem.getInstanceListaCombos(conexion).divisa ;
                if (divisas != null)
                {
                    box.DisplayMemberPath = "texto";
                    box.SelectedValuePath = "value";
                    box.ItemsSource = divisas;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void cargaDocumentos(System.Windows.Controls.ComboBox box, string conexion)
        {
            try
            {
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                dataset = bd.GetDataSet(CommandType.StoredProcedure, "[adquisicion].[SpCargaTipoDoctosxFact]");

                valores.Add(new Campo("CveTipoDocto"));
                texto.Add(new Campo("DescTipoDocto"));


                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(box, dataset, texto, valores);
                else
                    throw new Exception("La consulta efactor.carga_Divisa devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void cargaCliente(System.Windows.Controls.ComboBox box, string conexion)
        {
            try
            {


                List<ItemPersonalizado> cliente;
                cliente = ListaComunItem.getInstanceListaCombos(conexion).cedentes ;
                if (cliente != null)
                {
                    box.DisplayMemberPath = "texto";
                    box.SelectedValuePath = "value";
                    box.ItemsSource = cliente;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void cargaCliente(ComboBoxAutoBusqueda  box, string conexion)
        {
            try
            {

                List<ItemPersonalizado> cliente;
                cliente = ListaComunItem.getInstanceListaCombos(conexion).cedentes;
                if (cliente != null)
                {
                    box.listaOriginal = cliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void cargaCedidos(ComboBoxAutoBusqueda box, string conexion)
        {
            try
            {

                List<ItemPersonalizado> cliente;
                cliente = ListaComunItem.getInstanceListaCombos(conexion).cedidos;
                if (cliente != null)
                {
                    box.listaOriginal = cliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        
        }


        public static void cargaCedente(System.Windows.Controls.ComboBox box, string conexion)
        {
            try
            {
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                dataset = bd.GetDataSet(CommandType.Text, "CARGA_CEDENTES 'N'");

                valores.Add(new Campo("TC_NUM"));
                texto.Add(new Campo("TC_NOMBRE"));


                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(box, dataset, texto, valores);
                else
                    throw new Exception("La consulta efactor.carga_Divisa devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void cargaCesiones(System.Windows.Controls.ComboBox box, string cedente, string cedido, string conexion)
        {
            try
            {
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@CL_NUM", cedente));
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@TC_NUM", cedido));

                dataset = bd.GetDataSet(CommandType.StoredProcedure, "SP_CARGA_CESIONES_CASE");

                valores.Add(new Campo("CS_NUM"));
                texto.Add(new Campo("CS_NUM"));


                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(box, dataset, texto, valores);
                else
                    throw new Exception("La consulta efactor.carga_Divisa devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public static void cargaCesionesCedente(System.Windows.Controls.ComboBox box, string cedente, string conexion)
        {
            try
            {
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                bd.CadenaConexion = conexion;
                dataset = bd.GetDataSet(CommandType.Text, "CARGA_CEDENTES 'N'");

                valores.Add(new Campo("TC_NUM"));
                texto.Add(new Campo("TC_NOMBRE"));


                if (dataset != null)
                    ItemPersonalizado.cargaComboBox(box, dataset, texto, valores);
                else
                    throw new Exception("La consulta efactor.carga_Divisa devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void cargaCheques(System.Windows.Controls.ComboBox combo, string divisa, string dueño, string conexion)
        {
            try
            {
                SQLDataAcces bd = new SQLDataAcces();
                DataSet dataset;
                List<Campo> valores = new List<Campo>();
                List<Campo> texto = new List<Campo>();

                factoraje.clsCheque cheque = new factoraje.clsCheque();

                bd.CadenaConexion = conexion;
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@divisa", divisa));
                bd.ListaParametros.Add(new SQLDataAcces.Parametro("@dueno", dueño));
                dataset = bd.GetDataSet(CommandType.StoredProcedure, "cargabancos");



                valores.Add(new Campo("chk_cve"));

                texto.Add(new Campo("chk_fecha", "dd/MM/yyyy"));
                texto.Add(new Campo("chk_bancoD"));
                texto.Add(new Campo("chk_monto", "{0:Monto $#,##0.00;($#,##0.00);''}"));


                if (dataset != null)
                {
                    ItemPersonalizado.cargaComboBox(combo, dataset, texto, valores);


                }
                else
                    throw new Exception("La consulta cargabancos devolvio NULL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void llenaComboBoxArchivos(System.Windows.Controls.ComboBox combo, string path, string extension)
        {
            try
            {
                List<ItemPersonalizado> lista = new List<ItemPersonalizado>();

                
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);

                System.IO.FileInfo[] fileNames = info.GetFiles("*.xml");

                foreach (System.IO.FileInfo fi in fileNames)
                {
                    string[] aux;
                    aux = fi.Name.Split('.');
                    ItemPersonalizado item = new ItemPersonalizado();
                    item.texto = aux[0];
                    item.value = fi.Name;
                    lista.Add(item);
                }
                if (lista != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = lista;
                    combo.SelectedItem = lista[0];
                }
            }
            catch (System.IO.IOException ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Llena un combo de forma generica, se requiere especificar el nombre (string) de la propiedad texto y de la propiedad value dentro de la lista de objetos
        /// </summary>
        public static void cargaComboGenerico<T>(ref System.Windows.Controls.ComboBox combo, IEnumerable<T> lista, string value, string texto)
        {
            try
            {
                List<ItemPersonalizado> listaPersonalizada = new List<ItemPersonalizado>();
                foreach (var item in lista)
                {
                    ItemPersonalizado itemPersonalizado = new ItemPersonalizado()
                    {
                        texto = (Reflexiva.GetPropertyValue(item, texto) as string),
                        value = (Reflexiva.GetPropertyValue(item, value) as string)
                    };
                    listaPersonalizada.Add(itemPersonalizado);
                }
                if (listaPersonalizada != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = listaPersonalizada;
                    combo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cargaComboGenerico<T>(System.Windows.Controls.ComboBox combo, IEnumerable<T> lista, string value, string texto)
        {
            try
            {
                List<ItemPersonalizado> listaPersonalizada = new List<ItemPersonalizado>();
                foreach (var item in lista)
                {
                    ItemPersonalizado itemPersonalizado = new ItemPersonalizado()
                    {
                        texto = (Reflexiva.GetFieldOrPropertyValue(item, texto).ToString()),
                        value = (Reflexiva.GetFieldOrPropertyValue(item, value).ToString())
                    };
                    listaPersonalizada.Add(itemPersonalizado);
                }
                if (listaPersonalizada != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = listaPersonalizada;
                    combo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static void cargaCorreosSaliente(System.Windows.Controls.ComboBox combo,  conexion)
        //{
        //    IEnumerable<CorreoSaliente> correos;
        //    List<ItemPersonalizado> lista = new List<ItemPersonalizado>();
        //    correos = CorreoSaliente.getCorreosSaliente(conexion);
        //    try
        //    {
        //        foreach (var correo in correos)
        //            lista.Add(new ItemPersonalizado(correo.id.ToString(), correo.Cuenta));
        //        combo.DisplayMemberPath = "texto";
        //        combo.SelectedValuePath = "value";
        //        combo.ItemsSource = lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            
           
        //}

       
    }
}


        



    





    
