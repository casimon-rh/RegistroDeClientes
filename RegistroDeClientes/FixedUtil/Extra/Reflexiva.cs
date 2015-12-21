using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Extra
{
    public static class Reflexiva
    {
        public static object GetPropertyValue(this object car, string propertyName)
        {
            try
            {
                var a = car.GetType().GetProperties()
                       .Single(pi => pi.Name == propertyName);
                return a.GetValue(car, null);
            }
            catch (Exception)
            {
                return new object();
            }
        }
        public static object GetFieldValue(this object car, string propertyName)
        {
            try
            {
                var a = car.GetType().GetFields()
                        .Single(pi => pi.Name == propertyName);
                return a.GetValue(car);
            }
            catch (Exception)
            {
                return new object();
            }
        }
        public static object GetFieldOrPropertyValue(this object car, string name)
        {
            try
            {
                var a = car.GetType().GetProperties()
                      .Single(pi => pi.Name == name);
                return a.GetValue(car, null);
            }
            catch (Exception)
            {
                try
                {
                    var b = car.GetType().GetFields()
                           .Single(pi => pi.Name == name);
                    return b.GetValue(car);
                }
                catch (Exception)
                {
                    return new object();
                }
            }
        }

        public static List<PropertyInfo> GetAllProperties(this object car)
        {
            try
            {
                return car.GetType().GetProperties().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
