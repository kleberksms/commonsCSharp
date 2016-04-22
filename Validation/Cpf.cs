using System.Linq;
using System.Text.RegularExpressions;

namespace Validation
{
    /**
     * 
     * Code from http://jsfromhell.com
     */
    public class Cpf
    {
        private readonly string _cpf;

        public Cpf(string cpf)
        {
            _cpf = cpf;
        }

        public bool IsValid()
        {
            var regex = new Regex("[^0-9]");
            int[] c = regex.Replace(_cpf, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 11)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(new Regex($"/^{c[0]}{11}$/").Match(c.ToString()).ToString())) return false;

            var n = 0;
            var i = 0;
            for (var s = 10; s >= 2;)
            {
                n += c[i++]*s--;
            }
            if (c[9] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            n = 0;
            i = 0;
            for (var s = 11; s >= 2;)
            {
                n += c[i++]*s--;
            }
            if (c[10] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            return true;
            
        }
    }
}
