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
        string getNomSistema(string sis);
        Perfiles getPerfil(string cve_perfil);
        Perfiles getPerfil(string usuario, string empresa, string sistema);
        Perfiles getPerfil(Usuario usr);
        Usuario getUsr(int i);
        bool isAdministrador(string usuario, string empresa, string sistema);
        bool test(int usuario, string empresa, string sistema);
        Usuario iniciaSesion(string user, string pass);
        List<Modulo> getModuloPorPerfil(Sistema sis, Perfiles perfil);
        List<Modulo> getAllModulos(Sistema sis);
        List<Sistema> getSistemaPorPerfil(Perfiles perfil);
        List<Sistema> getAllSistemas();
        void cambiaContrasena(Usuario usr, string nContrasena);
        List<Empresa> getEmpresas();
    }
}
