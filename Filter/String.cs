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

        public static object FindFirstByMaskExpression(string mask, string text)
        {
            var result = string.Empty;


            Regex regex = new Regex(FormatterRegex(mask),
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant);

            Match match = regex.Match(text);

            if (match.Success)
            {
                result = match.Groups[1].Value;
            }

            return result;
        }

        public static string FormatterRegex(string formatter)
        {
            var regex = string.Empty;
            var countLetter = 1;
            var countNumber = 1;
            var aux = string.Empty;
            foreach (var letter in formatter)
            {
                if (countLetter > 1)
                {
                    if (letter.Equals('A'))
                    {
                        aux = "[A-Za-z]{" + Convert.ToString(countLetter) + "}";
                        countLetter++;
                    }
                    if (!letter.Equals('A'))
                    {
                        countLetter = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (countNumber > 1)
                {
                    if (letter.Equals('0'))
                    {
                        aux = @"\d{" + Convert.ToString(countNumber) + "}";
                        countNumber++;
                    }
                    if (!letter.Equals('0'))
                    {
                        countNumber = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (letter.Equals('A') && countLetter.Equals(1))
                {
                    aux = "[A-Za-z]";
                    countLetter++;
                }
                if (letter.Equals('0') && countNumber.Equals(1))
                {
                    aux = @"\d";
                    countNumber++;
                }
                if (letter.Equals(' '))
                {
                    aux = @"\s+";
                    regex += aux;
                    aux = string.Empty;
                }
                if (!letter.Equals('A') && !letter.Equals('0') && !letter.Equals(' '))
                {
                    aux = @"(\" + letter + ")";
                    regex += aux;
                    aux = string.Empty;
                }

            }
            regex += aux;
            return @"("+regex+")";
        }
    }
}
