using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Secure.Crypt
{

    public interface ICodifica<T>
    {
        String decode(T data);
        String code(T data);
    }

    [Serializable]
    public class CodificaDES : ICodifica<String>
    {

        private Byte[] bytes;
        private string _key;
        public String key { 
            get { 
                return _key; 
            } 
            set {
                _key = (value.ToCharArray().Length>8)? value.Substring(0,8): value.PadLeft(8,'0');
                bytes = ASCIIEncoding.ASCII.GetBytes(_key); 
            } 
        }


        public string decode(string data)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(data));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        public string code(string data)
        {

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(data);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
    }


    [Serializable]
    public class CodificaArchivo : ICodifica<StreamReader>
    {

        public ICodifica<String> codificador;



        public string decode(StreamReader data)
        {
            StringBuilder builder = new StringBuilder();
            return codificador.decode(data.ReadToEnd());
        }

        public String code(StreamReader data)
        {
            StringBuilder builder = new StringBuilder();
            return codificador.code(data.ReadToEnd());
        }
    }
}
