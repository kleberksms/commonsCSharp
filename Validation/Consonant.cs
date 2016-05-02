using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Consonant
    {
        private string _c;

        public Consonant(string c)
        {
            _c = c;
        }

        public bool IsConsonant()
        {
            if (_c.Length > 1)
            {
                throw new Exception("Use IsSetOfConsonants");
            }
            var regex = new Regex(@"[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z]");
            return regex.IsMatch(_c);
        }

        public bool IsSetOfConsonants()
        {
            var regex = new Regex(@"^(\s|[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z])*$");
            return regex.IsMatch(_c);
        }

        public bool ContainsConsonant()
        {
            var constains = false;
            var regex = new Regex(@"[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z]");
            foreach (var c2 in _c.Where(c2 => regex.IsMatch(c2.ToString())))
            {
                constains = true;
            }

            return constains;
        }
    }
}
