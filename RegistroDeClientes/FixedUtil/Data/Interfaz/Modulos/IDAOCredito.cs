using Data.Linq.Mapping.Credi100;
using System;
using System.Collections.Generic;
namespace Data.Interfaz
{
    public interface IDAOCredito
    {
        List<Acclien> getAcclien();
        List<Acrecibo> getAcrecibo();
        List<Acrecibo> getAcrecibo(Acclien cliente);
        //List<Años> getAños();
        List<Avales> getAvales();
        List<Co_antic> getCo_antic();
        List<Co_antic_saldo> getCo_antic_saldo();
        List<Co_cesio> getCo_cesio();
        List<Co_saldo> getCo_saldo();
        List<Co_titce> getCo_titce();
        List<Firmas> getFirmas();
        List<Monedas> getMonedas();
        List<Productos> getProductos();
        List<AcRecibo_tmp> getAcRecibo_tmp();
        List<TMP_HOJA_CALCULO> getTMP_HOJA_CALCULO();
        void borraRecibo_tmp();
    }
}
