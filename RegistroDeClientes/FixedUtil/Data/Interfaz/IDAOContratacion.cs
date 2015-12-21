using Data.Linq.Mapping.ComunInfo100;
using Data.Linq.Mapping.Factor100;
using System;
using System.Collections.Generic;
namespace Data.Linq.Interfaz
{
    public interface IDAOContratacion
    {
        bool existeDuplicado(string razonSocial, string RFC = "");
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.Clientes> getClientes();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.CatalogoBancos> getBancos();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.CatalogoABASwift> getCatalogoABASwift();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.CatalogoChequera> getCatalogoChequera();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.Clientes> getClients();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.Factor100.ProductoFactoraje> getProductoFactoraje();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.ProductoPromotor> getProductoPromocion();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.Promotores> getPromotores();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.ComunInfo100.Clientes> getPRVS();
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.Factor100.TipoDocumento> getTipoDocumento();
        global::Data.Linq.Mapping.Factor100.Relacion obtieneRelacion(string idDeudor, string idCliente, string idTipoFac, string idTipoDocumento);
        global::System.Collections.Generic.List<global::Data.Linq.Mapping.Factor100.Divisas> getDivisas();
        string obtieneUltimoId();
        string obtieneUltimoId(global::Data.Linq.Mapping.ComunInfo100.TipoCliente tipo);
        bool existeTipoPersona(string tipo);
        bool existeProfesion(int id);
        bool existeProfesion(string prof);
        bool existeRegimenF(int id);
        bool existeRegimenF(string regimen);
        bool existeNacionalidad(int id);
        bool existeNacionalidad(string nacionalidad);
        bool existeGiro(int id);
        bool existeGiro(string giro);
        bool existeCodigoPostal(string codigo, string idPais);
        bool existeBanco(string banco);
        bool existeBanco(int id);
        bool existeEntidad(string entidad);
        bool existeEntidad(int id);
        bool existeLugarOrigen(int id);
        bool existeLugarOrigen(string lugar);
        global::Data.Linq.Mapping.ComunInfo100.RegimenFiscal getRegimenFiscal(int id);
        global::Data.Linq.Mapping.ComunInfo100.Direcciones getValoresDireccion(string codigoPostal, string idpais, string NUMERO_INTERIOR, string NUMERO_EXTERIOR, string CALLE, string COLONIA);
        DateTime getFechaSistema();
        string getNumeroPersona();
        int getIdRegimen(string regimen);
        int getIdLugarOrigen(string lugarOrigen);
        int getIdProfesion(string profesion);
        int getIdNacionalida(string nacionalidad);
        string getNumeroTipoCliente(string algo);
        List<global::Data.Linq.Mapping.ComunInfo100.TipoAbonoDeCheque> getCL_MOVIM();
        int getPlazoMaximo(global::Visualize.Controles.ComboBox.ItemPersonalizado deudor, global::Visualize.Controles.ComboBox.ItemPersonalizado producto);
        int getPlazoMinimo(global::Visualize.Controles.ComboBox.ItemPersonalizado deudor, global::Visualize.Controles.ComboBox.ItemPersonalizado producto);
        global::Data.Linq.Mapping.ComunInfo100.TmpUltimoCliente getUltimoCliente(string tipo);
        DateTime getFecha();
        bool existeNivelRiesgo(string nivel);
        bool existeRelacionId(string prv, string NoSirac);
        global::Data.Linq.Mapping.Factor100.Divisas getDivisaPorProducto(string IDProducto);
        global::Data.Linq.Mapping.Factor100.Divisas getDivisaPorProducto(int Tipo_factoraje);
        List<CatalogoPaises> getPaises();
        int getIDPais(String pais);
        global::Data.Linq.Mapping.ComunInfo100.CatalogoABASwift getABASwift(int id);
        int getIdTipoPersona(global::Data.Linq.Mapping.ComunInfo100.Clientes cliente);
        int getUltimoIdPersona();
        global::Data.Linq.Mapping.ComunInfo100.CatalogoBancos getBanco(string banco);
        global::Data.Linq.Mapping.ComunInfo100.CatalogoBancos getBanco(int id);
        global::Data.Linq.Mapping.ComunInfo100.Clientes getCliente(int num_persona);
        global::Data.Linq.Mapping.ComunInfo100.TipoAbonoDeCheque getTipoAbono(int idTipo);
        List<CatalogoEstructuraTasa> getEstructuras();
        List<CatalogoTasasBase> getTasasBase();
        void updateDetalleTasa(CatalogoTasasDetalle obj);

        List<TipoCliente> getPerfilesPersona(String p);

        List<TipoCliente> getPerfilesPersona(int p);

        Clientes getClientePorNumCliente(string cliente);

        DatosAdicionales ConsultaDatosAdicionales (string p);
         string getIDBanco(string p);
    }
}
