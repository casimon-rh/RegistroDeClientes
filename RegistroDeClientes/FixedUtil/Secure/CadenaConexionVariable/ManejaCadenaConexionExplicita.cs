using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Secure.CadenaConexionVariable
{





    public class ManejaCadenaConexionExplicita: IManejaCadenaConexion
    {
        //"Data Source=?server?;Initial Catalog=?base?;Persist Security Info=True;User ID=?user?;Password=?pass?"
        //"PROVIDER=MSDataShape;DRIVER=SQL Server;SERVER=?server?;UID=?user?;PASSWORD=?pass?;DATABASE=?base?"
        private string cadena;
        private string usuario;
        private string password;
        private string server;
        #region Publics
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
        public string Server
        {
            get { return server; }
            set { server = value; }
        } 
        #endregion
        public string getCadenaConexion(string cadena)
        {
            return Cadena.Replace("?server?", server).Replace("?base?",cadena).Replace("?user?",usuario).Replace("?pass?",password);
        }
        public string getCadenaConexion()
        {
            return Cadena.Replace("?server?", server).Replace("?base?", cadena).Replace("?user?", usuario).Replace("?pass?", password);
        }
    }
}
