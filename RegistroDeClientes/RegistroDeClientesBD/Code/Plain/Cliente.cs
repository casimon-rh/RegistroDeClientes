using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroDeClientesBD.Plain
{
    public class Cliente
    {
        private int _IdCliente;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private DateTime _FechaAlta;
        private double _Credito;
        private double _Deuda;

        public double Deuda
        {
            get { return _Deuda; }
            set { _Deuda = value; }
        }
        public double Credito
        {
            get { return _Credito; }
            set { _Credito = value; }
        }


        public DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }


        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; }
        }


        public string ApPaterno
        {
            get { return _ApPaterno; }
            set { _ApPaterno = value; }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int IdCliente
        {
            get { return IdCliente; }
            set { IdCliente = value; }
        }
    }
}
