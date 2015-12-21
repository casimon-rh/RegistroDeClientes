using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Data.Interfaz;
using Data.Linq.Mapping.Seguridad;

namespace Secure.XAML
{
    public class SeguridadXAML : IDaoSeguridad
    {

        private string nombreSistema;
        private string empresa;
        private string modulo;
        private string idSistema;

        private IDaoMenu daoMenu
        {
            get;
            set;
        }
        public SeguridadXAML(IDaoMenu dao)
        {
            this.daoMenu = dao;
        }

        private void insertaSeguridad( string sistema, string modulo, string nombreSistema, int esquema, int reporte, int subreporte, int subsubnivel ,string nombre)
        {
            SeguridadMaestra sec = new SeguridadMaestra();
            sec.perfil = null;
            sec.sistema = nombreSistema;
            sec.modulo = modulo;
            sec.esquema = esquema;
            sec.reporte = reporte;
            sec.subreporte = subreporte;
            sec.nombre = nombre;
            sec.cvesssubmenu = subsubnivel;
            daoMenu.insertaMenu(sec);
        }
        private int Ascendencia(MenuItem dp, int i)
        {

            if (dp.Parent != null)
                if (dp.Parent is Menu)
                {
                    return i;
                }
                else
                {
                    i++;
                    return Ascendencia(dp.Parent as MenuItem, i);
                }
            return i;
        }

        private void insertaMenuSeguridad(DependencyObject dp, Int32 raiz, Int32 nivel, Int32 subNivel, Int32 subsubNivel)
        {
             bool tope=false;
            Int32 tamano = 0;
            MenuItem menu = null;
            if (dp is Menu)
            {
                Menu auxMenu = dp as Menu;
                if (auxMenu.HasItems)
                {
                    for (int i = 1; i <= auxMenu.Items.Count; i++)
                    {
                        MenuItem menuItem=null;
                        if (!(auxMenu.Items.GetItemAt(i - 1) is Separator))
                            menuItem = (MenuItem)auxMenu.Items.GetItemAt(i - 1);
                        else continue;
                        raiz = i;
                        insertaMenuSeguridad(menuItem as DependencyObject, raiz, nivel, subNivel, subsubNivel);

                    }

                }
            }
            else if (dp is MenuItem)
            {
                menu = dp as MenuItem;
                if(!tope)inserto(raiz, nivel, subNivel, subsubNivel, menu.Header.ToString());
                if (menu.HasItems)
                {
                    for (int i = 1; i <= menu.Items.Count; i++)
                    {
                        MenuItem menuItem = null;
                        if (!(menu.Items.GetItemAt(i - 1) is Separator))
                            menuItem = (MenuItem)menu.Items.GetItemAt(i - 1);
                        else continue;
                        tope = false;
                        switch (Ascendencia(menuItem, 0))
                        {
                            case (0):
                                raiz = i;
                                break;
                            case (1):
                                nivel = i;
                                break;
                            case (2):
                                subNivel = i;
                                break;
                            case (3):
                                subsubNivel = i;
                                break;
                            default:
                                tope = true;
                                break;
                        }
                        insertaMenuSeguridad(menuItem as DependencyObject, raiz, nivel, subNivel, subsubNivel);

                    }
                }
            }
            else
            {
                tamano = VisualTreeHelper.GetChildrenCount(dp);
                for (int z = 0; z < tamano; z++)
                {
                    Object cc = VisualTreeHelper.GetChild(dp, z);
                    if (cc is DependencyObject)
                    {
                        insertaMenuSeguridad(cc as DependencyObject, raiz, nivel, subNivel, subsubNivel);
                    }
                }
            }



        }

        private void inserto(int raiz, int nivel, int subNivel, int subsubNivel, String p)
        {
            insertaSeguridad(idSistema, modulo, nombreSistema, raiz, nivel, subNivel, subsubNivel, p);
            Console.WriteLine(" Raiz " + raiz + " nIVEL " + nivel + " SubNivel " + subNivel + " Subreporte " + subsubNivel + " Nombre " + p);
        }



        public void insertaMenusenSeguridadMaestra(object proxy ,string idSistema, string nombreSistema,String modulo, string empresa)
        {
            DependencyObject window = null;



            if (proxy is DependencyObject)
            {

                window = proxy as DependencyObject;
                this.idSistema = idSistema;
                this.modulo = modulo;
                this.nombreSistema = nombreSistema;
                this.empresa = empresa;



               if (daoMenu.borraMenuPorModulo(modulo))
                   insertaMenuSeguridad(window, 0, 0, 0, 0);
            }
            else
                throw new Exception("DependencyIncorrect");
        }
        public void insertaMenusenSeguridadMaestra(object proxy, string idSistema, string nombreSistema, String modulo, string empresa, bool sobreescribe)
        {
            DependencyObject window = null;



            if (proxy is DependencyObject)
            {

                window = proxy as DependencyObject;
                this.idSistema = idSistema;
                this.modulo = modulo;
                this.nombreSistema = nombreSistema;
                this.empresa = empresa;


                if(sobreescribe)
                    insertaMenuSeguridad(window, 0, 0, 0, 0);
                else if (daoMenu.borraMenuPorModulo(modulo))
                    insertaMenuSeguridad(window, 0, 0, 0, 0);
            }
            else
                throw new Exception("DependencyIncorrect");
        }

        public string getNomSistema(string sis)
        {
            throw new NotImplementedException();
        }

        public Perfiles getPerfil(string cve_perfil)
        {
            throw new NotImplementedException();
        }

        public Perfiles getPerfil(string usuario, string empresa, string sistema)
        {
            throw new NotImplementedException();
        }

        public Usuario getUsr(int i)
        {
            throw new NotImplementedException();
        }

        public bool isAdministrador(string usuario, string empresa, string sistema)
        {
            throw new NotImplementedException();
        }

        public bool test(int usuario, string empresa, string sistema)
        {
            throw new NotImplementedException();
        }


        public Perfiles getPerfil(Usuario usr)
        {
            throw new NotImplementedException();
        }

        public Usuario iniciaSesion(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public List<Modulo> getModuloPorPerfil(Sistema sis, Perfiles perfil)
        {
            throw new NotImplementedException();
        }

        public List<Modulo> getAllModulos(Sistema sis)
        {
            throw new NotImplementedException();
        }

        public List<Sistema> getSistemaPorPerfil(Perfiles perfil)
        {
            throw new NotImplementedException();
        }

        public List<Sistema> getAllSistemas()
        {
            throw new NotImplementedException();
        }

        public void cambiaContrasena(Usuario usr, string nContrasena)
        {
            throw new NotImplementedException();
        }


        public List<Empresa> getEmpresas()
        {
            throw new NotImplementedException();
        }


        public void refresh(string cn)
        {
            throw new NotImplementedException();
        }


        public List<CadenasConexion> getCadenaConexion(Empresa emp)
        {
            throw new NotImplementedException();
        }

        public Sistema getSistema(int id)
        {
            throw new NotImplementedException();
        }


        public List<CadenasConexion> getCadenaConexion(Sistema sistema)
        {
            throw new NotImplementedException();
        }


        public List<CadenasConexion> getCadenaConexion(Sistema sistema, Empresa emp)
        {
            throw new NotImplementedException();
        }


        public Usuario getUsr(string usuarioLogin)
        {
            throw new NotImplementedException();
        }

        public IContexto getContexto()
        {
            throw new NotImplementedException();
        }


        public List<Perfiles> getPerfilesUsuario(Usuario usr)
        {
            throw new NotImplementedException();
        }


        public List<CadenasConexionComunes> getCadenaConexionComunes()
        {
            throw new NotImplementedException();
        }


        public bool isBloqued(string user)
        {
            throw new NotImplementedException();
        }
    }
}
