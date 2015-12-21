using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Data.XML
{
    public static class FuncionsXML
    {
        public static T deserializeObject<T>(this T obj, String xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var aux = new StringReader(xml))
                {
                    obj = (T)serializer.Deserialize(aux);
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SerializeObject<T>(this T obj, StreamWriter xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(xml, obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string SerializeObject<T>(this T obj, StringWriter xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(xml, obj);
                return xml.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
