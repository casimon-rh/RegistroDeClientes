using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaz.Modulos
{
    public interface IDaoReportes
    {
        Data.Linq.Mapping.Factor100.VariablesConfiguracion obtieneVariablesConfiguracion();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClienteDeudores();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClienteEpos();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClienteProveedores();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClientes();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClientesConCondicionesFinancieras();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClientesTodosTipos();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClientesYDeudoresLineasDeCredito();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getDeudorEpos();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getDeudores();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getDeudoresConCondicionesFinancieras();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getEpos();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getProveedores();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getProveedoresDeudores();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getProveedoresEpo();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.RelacionClienteLinea> getRelacionClientesLinea();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.RelacionClienteLinea> getRelacionClientesLinea(Data.Linq.Mapping.ComunInfo100.Clientes _cl);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.Cesion> getCesionesCliente(Data.Linq.Mapping.ComunInfo100.Clientes _cl);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.ChequesIngresados> getChequesFactorajeActivos();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.CuentasBancariasFinanciera> getCuentasFinanciera();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.Cesion> getCesiones();
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getClientesProveedoresPorDeudoresEpos(Data.Linq.Mapping.ComunInfo100.Clientes _cl);
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.Clientes> getDeudoresEposPorClientesProveedores(Data.Linq.Mapping.ComunInfo100.Clientes _cl);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.Cesion> getCesiones(Data.Linq.Mapping.ComunInfo100.Clientes _cl);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.Cesion> getCesiones(Data.Linq.Mapping.ComunInfo100.Clientes Cedente, Data.Linq.Mapping.ComunInfo100.Clientes Deudor);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.IntermediarioFinanciero> getDatosIntermediario();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.Operadores> getOperadores();
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.LineaDeCredito> getLineaDeClienteProveedor(Data.Linq.Mapping.ComunInfo100.Clientes Cedente, Data.Linq.Mapping.Factor100.Divisas divisa);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.LineasCreditoGeneral> getLineaDeCreditoGeneral(Data.Linq.Mapping.ComunInfo100.Clientes Cliente_Deudor, Data.Linq.Mapping.Factor100.Divisas divisa, bool Deudor);
        System.Collections.Generic.List<Data.Linq.Mapping.Factor100.OrigenesCartera> getOrigenesCartera();
        Data.Linq.Mapping.Factor100.TituloDeCredito getTituloCreditoPorDCNUM(string DC_NUM);
        Data.Linq.Mapping.Factor100.CuentasBancarias getCuentaPorCliente(Data.Linq.Mapping.ComunInfo100.Clientes cl, Data.Linq.Mapping.Factor100.Divisas dv);
        Data.Linq.Mapping.ComunInfo100.CatalogoBancos getBanco(string EB_NUM);
        System.Collections.Generic.List<Data.Linq.Mapping.ComunInfo100.CatalogoDeFondeadores> getFondeadores();
    }
}
