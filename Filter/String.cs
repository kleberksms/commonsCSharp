using System;
using System.Text.RegularExpressions;

namespace Filter
{
    public static class String
    {

        public static string Slugfy(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   

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
    }
}
