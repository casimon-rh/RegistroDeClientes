using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Data.Interfaz
{
    public abstract class IBitacora
    {
        private int? _UFACTOR;
        public int UFACTOR { get { return _UFACTOR ?? -1; } set { _UFACTOR = value; } }
        public string UWINDOWS
        {
            get { return Environment.UserName; }
            
        }
        public string IP
        {
            get
            {
                return (from IPAddress ip 
                            in Dns.GetHostEntry(Dns.GetHostName()).AddressList 
                        where ip.AddressFamily == AddressFamily.InterNetwork 
                        select ip.ToString()).FirstOrDefault();
            }
            
        }
        public DateTime FECHA
        {
            get { return DateTime.Now; }
            
        }
        public string id
        {
            get { return Process.GetCurrentProcess().Id.ToString(); }
           
        }
        public abstract void registraBitacora(string tipo_accion, string descripcion);
        public abstract void refresh(string cn);
    }
}
