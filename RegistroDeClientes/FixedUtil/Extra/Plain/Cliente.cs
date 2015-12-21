using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extra.Plain
{
    [Serializable]
    public class Cliente
    {
        private int _IdCliente;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private DateTime _FechaAlta;
        private double _Credito;
        private double _Deuda;

        public Cliente()
        {
            _IdCliente = 0;
            _Nombre = "";
            _ApPaterno = "";
            _ApMaterno = "";
            _FechaAlta = DateTime.Now;
            _Credito = 0;
            _Deuda = 0;
        }

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
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
    }
}
