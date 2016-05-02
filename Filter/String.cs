using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Filter
{
    public static class String
    {

        public static string Slugfy(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();       
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string Excerpt(this string phrase, int length = 150, string ommission = "...")
        {
            if (phrase == null || phrase.Length < length)
                return phrase;
            var iNextSpace = phrase.LastIndexOf(" ", length, StringComparison.Ordinal);
            return $"{phrase.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim()}{ommission}";
        }

        public static string OnlyNumbers(string input)
        {
            var rgx = new Regex("[^0-9]");
            var result = rgx.Replace(input, "");
            return result;
        }

        public static string OnlyAlphanumerics(string input)
        {
            var rgx = new Regex("[^A-Za-z0-9]");
            var result = rgx.Replace(input, "");
            return result;
        }

        public static object FindFirstByMaskExpression(string mask, string text)
        {
            var regex = new Regex(FormatterRegex(mask),
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant);

            var match = regex.Match(text);

            var result = match.Groups[1].Value;

            return result;
        }

        public static List<string> FindListByMaskExpression(string mask, string text)
        {
            var list = new List<string>();
            var regex = new Regex(FormatterRegex(mask),
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant);

            var matchs = regex.Matches(text);

            foreach (Match match in matchs)
            {
                list.Add(match.Value);
            }
            return list;
        }

        public static string FormatterRegex(string formatter)
        {
            var regex = string.Empty;
            var countLetter = 1;
            var countNumber = 1;
            var aux = string.Empty;

            foreach (var chars in formatter)
            {
                if (countLetter > 1)
                {
                    if (chars.Equals('A'))
                    {
                        aux = "[A-Za-z]{" + Convert.ToString(countLetter) + "}";
                        countLetter++;
                    }
                    if (!chars.Equals('A'))
                    {
                        countLetter = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (countNumber > 1)
                {
                    if (chars.Equals('0'))
                    {
                        aux = @"\d{" + Convert.ToString(countNumber) + "}";
                        countNumber++;
                    }
                    if (!chars.Equals('0'))
                    {
                        countNumber = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (chars.Equals('A') && countLetter.Equals(1))
                {
                    aux = "[A-Za-z]";
                    countLetter++;
                }
                if (chars.Equals('0') && countNumber.Equals(1))
                {
                    aux = @"\d";
                    countNumber++;
                }
                if (chars.Equals(' '))
                {
                    aux = @"\s+";
                    regex += aux;
                    aux = string.Empty;
                }
                if (!chars.Equals('A') && !chars.Equals('0') && !chars.Equals(' '))
                {
                    aux = @"(\" + chars + ")";
                    regex += aux;
                    aux = string.Empty;
                }
            }
            regex += aux;
            return @"("+regex+")";
        }

        public static string GetBetween(string strSource, string strStart, string strEnd, bool inclusive = false)
        {
            if (!strSource.Contains(strStart) || !strSource.Contains(strEnd)) return string.Empty;

            var start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
            var end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
            if (inclusive)
            {
                return strStart + strSource.Substring(start, end - start) + strEnd;
            }
            return strSource.Substring(start, end - start).Trim();
        }

        public static object AddMask(string mask, string source)
        {
            source = OnlyAlphanumerics(source);
            for (var i = 0; i < mask.Length; i++)
            {
                if (!mask[i].Equals('A') && !mask[i].Equals('0'))
                {
                    source = source.Insert(i, mask[i].ToString());
                }
            }
            return source;
        }
    }
}
