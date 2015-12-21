using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    public interface ISQLDataAcces
    {
        string CadenaConexion { get; set; }
        void ExecuteNonQuery(System.Data.CommandType _tipoComando, string _cadenaComando);
        System.Data.DataSet GetDataSet(System.Data.CommandType _tipoComando, string _cadenaComando);
        System.Data.DataView GetDataView(System.Data.CommandType _tipoComando, string _cadenaComando);
        object GetOutput(System.Data.CommandType _tipoComando, string _cadenaComando);
        object GetRow(System.Data.CommandType _tipoComando, string _cadenaComando);
    }
}
