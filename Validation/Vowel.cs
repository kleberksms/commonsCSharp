using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Vowel
    {
        private readonly string _v;

        public Vowel(string v)
        {
            _v = v;
        }

        public bool IsVowel()
        {
            if (_v.Length > 1)
            {
                throw new Exception("Use IsSetOfVowels");
            }
            var regex = new Regex(@"[aeiouAEIOU]");
            return regex.IsMatch(_v);
        }

        public bool IsSetOfVowels()
        {
            var regex = new Regex(@"^(\s|[aeiouAEIOU])*$");
            return regex.IsMatch(_v);
        }

        public bool ContainsVowel()
        {
            var constains = false;
            var regex = new Regex(@"[aeiouAEIOU]");
            foreach (var v2 in _v.Where(v2 => regex.IsMatch(v2.ToString())))
            {
                constains = true;
            }

            return constains;
        }
    }
}
