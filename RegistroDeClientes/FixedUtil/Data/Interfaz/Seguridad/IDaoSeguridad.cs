using Data.Linq.Mapping.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    public interface IDaoSeguridad
    {
        IContexto getContexto();
        string getNomSistema(string sis);
        Perfiles getPerfil(string cve_perfil);
        Perfiles getPerfil(string usuario, string empresa, string sistema);
        List<Perfiles> getPerfilesUsuario(Usuario usr);
        Usuario getUsr(int i);
        Usuario getUsr(string usuarioLogin);
        bool isAdministrador(string usuario, string empresa, string sistema);
        bool test(int usuario, string empresa, string sistema);
        Usuario iniciaSesion(string user, string pass);
        List<Modulo> getModuloPorPerfil(Sistema sis, Perfiles perfil);
        List<Modulo> getAllModulos(Sistema sis);
        List<Sistema> getSistemaPorPerfil(Perfiles perfil);
        List<Sistema> getAllSistemas();
        void cambiaContrasena(Usuario usr, string nContrasena);
        List<Empresa> getEmpresas();
        void refresh(string cn);
        List<CadenasConexion> getCadenaConexion(Empresa emp);
        Sistema getSistema(int id);
        List<CadenasConexion> getCadenaConexion(Sistema sistema, Empresa emp);
        List<CadenasConexionComunes> getCadenaConexionComunes();
        bool isBloqued(string user);
    }
}
