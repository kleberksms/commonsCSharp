using System;

namespace Validation
{
    public class PrimeNumber
    {
        private int _number;

        public PrimeNumber(int number)
        {
            _number = number;
        }

        public bool IsPrime()
        {
            if(_number <= 1) return false;

            if (_number != 2 && (_number%2) == 0) return false;

            for (var i = 3; i < Math.Ceiling(Math.Sqrt(_number)); i+= 2)
            {
                if ((_number%i) == 0) return false;
            }
            return true;
        }
    }
}
