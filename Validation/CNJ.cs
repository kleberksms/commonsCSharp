using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Cnj
    {
        private readonly string _cnj;

        public Cnj(string cnj)
        {
            var regex = new Regex("[^0-9]");
            cnj = regex.Replace(cnj, "");
            
            if (cnj.Length < 20)
            {
                cnj = cnj.PadLeft(20, Convert.ToChar("0"));
            }
            _cnj = cnj;

        }

        public bool IsValid( )
        {
            return _cnj.Equals(_cnj.Remove(7, 2).Insert(7,(98 - (Convert.ToDecimal($"{_cnj.Remove(7, 2)}00") % 97)).ToString(CultureInfo.CurrentCulture)));
        }

    }
}
