using Validation;

namespace Filter
{
    public class Integer
    {
        public int FindPrimeNumber(int i)
        {
            var found = false;
            if (i.Equals(1)) return 2;
            if (i.Equals(2)) return 3;
            if (i.Equals(3)) return 5;

            int start = 7;
            int position = 4;
            int result = 0;
            while (!found)
            {
                long lastDigit = start % 10;
                if (!(lastDigit.Equals(1) || lastDigit.Equals(3) || lastDigit.Equals(7) || lastDigit.Equals(9)))
                {
                    start++;
                    continue;
                }
              
                if (position.Equals(i))
                {
                    found = true;
                }

                var p = new PrimeNumber(start);
                if (p.IsPrime())
                {
                    position++;
                    result = start;
                }
                start++;
                
            }
            return result;
        }
    }
}
