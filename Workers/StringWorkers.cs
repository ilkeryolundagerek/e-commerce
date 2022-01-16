using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.Workers
{
    public class StringWorkers
    {
        public static string toSeoUrl(string text)
        {
            text = GetByteArray(text);
            text = text.Trim().ToLower();
            text = text.Replace("ş", "s").Replace("ç", "c").Replace("ı", "i").Replace("ö", "o").Replace("ü", "u").Replace("ğ", "g");
            text = Regex.Replace(text, @"\s+", "-");

            return text;
        }

        private static string GetByteArray(string text)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
