using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Extra
{
    public static class Funciones
    {
        public static T Max<T>(T value1, T value2) where T : IComparable
        {
            return value1.CompareTo(value2) > 0 ? value1 : value2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="interval">
        /// case "Year":         
        ///        case "Month":
        ///        case "Week":
        ///        case "Day":
        ///        case "Hour":
        ///        case "Minute":
        ///        case "Second":
        /// </param>
        /// <returns></returns>
        public static Int64 Span(DateTime begin, DateTime end, string interval)
        {

            // Verify arguments


            // Define count
            TimeSpan span = end - begin;
            switch (interval)
            {
                case "Year":
                    return (Int64)(end.Year - begin.Year);
                case "Month":
                    return (Int64)((end.Month - begin.Month) + (12 * (end.Year - begin.Year)));
                case "Week":
                    return (Int64)Math.Floor(span.TotalDays) / 7;
                case "Day":
                    return (Int64)Math.Floor(span.TotalDays);
                case "Hour":
                    return (Int64)Math.Floor(span.TotalHours);
                case "Minute":
                    return (Int64)Math.Floor(span.TotalMinutes);
                case "Second":
                    return (Int64)Math.Floor(span.TotalSeconds);
                default:
                    return (Int64)span.Ticks;
            }

        } // Span
        public static int dameAleatorio()
        {
            Random rnd;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[24];
            int semilla;
            rng.GetBytes(buffer);
            semilla = BitConverter.ToInt32(buffer, 0);
            rnd = new Random(semilla);
            return rnd.Next();
        }
    }
}
