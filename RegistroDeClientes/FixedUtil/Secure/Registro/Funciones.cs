using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure.Registro
{
    public static class Funciones
    {

        public static void escribeEntradaWithKey(string entrada, string key, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int separador = 92;
                    int i = 0;
                    RegistryKey registryKey = Registry.CurrentUser;
                    if (!existeEntrada(entrada)) 
                        registryKey.CreateSubKey(entrada, RegistryKeyPermissionCheck.ReadWriteSubTree);
                  
                  
                    foreach (var aux in entrada.Split((char)separador))
                            registryKey = registryKey.OpenSubKey(aux, true);

                    //registryKey = registryKey.OpenSubKey(entrada);

                    registryKey.SetValue(key, value, RegistryValueKind.String);
                
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public static void escribeEntrada(string subkey, string key, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    RegistryKey rkCurrentUser = Registry.CurrentUser;
                    RegistryKey rkSoftware = rkCurrentUser.OpenSubKey("Software", true);
                    RegistryKey rkInfo100 = rkSoftware.CreateSubKey("INFO100", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    RegistryKey rkTest = rkInfo100.OpenSubKey(subkey, true);
                    (rkTest??rkInfo100.CreateSubKey(subkey, RegistryKeyPermissionCheck.ReadWriteSubTree)).SetValue(key, value, RegistryValueKind.String);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void borraEntrada()
        {
            try
            {
                RegistryKey rkCurrentUser = Registry.CurrentUser;
                RegistryKey rkSoftware = rkCurrentUser.OpenSubKey("Software",true);
                rkSoftware.DeleteSubKeyTree("INFO100", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool existeEntrada(string key) {
            try
            {
                RegistryKey rkCurrentUser = Registry.CurrentUser;
                RegistryKey keyReg = rkCurrentUser.OpenSubKey(key);
                return keyReg != null;
            }
            catch (Exception)
            {
                return false;
            }
        
        }
        

        public static bool existeEntradaSoftware(string key)
        {
            try
            {
                RegistryKey rkCurrentUser = Registry.CurrentUser;
                RegistryKey rkSoftware = rkCurrentUser.OpenSubKey("Software");
                RegistryKey rkTest = rkSoftware.OpenSubKey(key, false);
                return rkTest!=null;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static void borraEntrada(string entrada)
        {
            try
            {
                RegistryKey rkCurrentUser = Registry.CurrentUser;
                if (existeEntrada(entrada))
                    rkCurrentUser.DeleteSubKeyTree(entrada);
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }
    }
}
