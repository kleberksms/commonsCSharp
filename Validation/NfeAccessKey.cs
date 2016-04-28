﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Math;

namespace Validation
{
    public class NfeAccessKey
    {
        private string _accessKey;
        public NfeAccessKey(string accessKey)
        {
            _accessKey = accessKey;
        }

        public bool IsValid()
        {
            var regex = new Regex("[^0-9]");
            int[] c = regex.Replace(_accessKey, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 44)
            {
                return false;
            }

            int[] w = new int[44];
            var z = 5;
            var m = 43;
            for (var i = 0; i <= m; ++i)
            {
                z = (i < m) ? (z - 1) == 1 ? 9 : (z - 1) : 0;
                w[i] = z;
            }
            int s = 0;
            var k = 44;
            for (int i = 0; i < k; ++i)
            {
                s += c[i]*w[i];
            }

            s -= (int) (11 * Convert.ToInt64(Math.Floor(Convert.ToDecimal(s / 11))));
            var v = (s == 0 || s == 1) ? 0 : (11 - s);

            return v.Equals(c[43]);
        }
    }
}
