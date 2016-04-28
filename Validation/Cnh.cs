using System.Linq;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Cnh
    {
        private string _cnh;

        public Cnh(string cnh)
        {
            _cnh = cnh;
        }

        public bool IsValid()
        {
            var ret = false;

            var regex = new Regex("[^0-9]");
            int[] c = regex.Replace(_cnh, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 11)
            {
                return false;
            }

            var dsc = 0;
            var j = 9;
            var v = 0;
            for (var i = 0; i < 9; ++i, --j)
            {
                v += c[i] * j;
            }
            var vl1 = v % 11;
            if (vl1 >= 10)
            {
                vl1 = 0;
                dsc = 2;
            }
            j = 1;
            v = 0;
            for (var i = 0; i < 9; ++i, ++j)
            {
                v += c[i]*j;
            }
            var vl2 = ((v % 10) >= 10) ? 0 : (v % 10) - dsc;
            
            return _cnh.Substring(9,2).Equals($"{vl1}{vl2}");
        }
    }
}
