using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Validation
{
    /**
     * 
     * Code from http://jsfromhell.com
     */
    public class Cnpj
    {
        private string _cnpj ;
        public Cnpj(string cnpj)
        {
            _cnpj = cnpj;
        }

        public bool IsValid()
        {
            var regex = new Regex("[^0-9]");
            var c = regex.Replace(_cnpj, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 14)
            {
                return false;
            }
            int[] b = {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            var n = 0;
            for (var i = 0; i < 12;)
            {
                n += c[i]*b[++i];
            }
            if (c[12] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            n = 0;
            for (var i = 0; i <= 12;)
            {
                n += c[i]*b[i++];
            }
            if (c[13] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            return true;
        }
    }
}
