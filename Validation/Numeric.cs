

namespace Validation
{
    public class Numeric 
    {
        public virtual bool Validate(string input)
        {
            int value;
            return int.TryParse(input, out value);
        }
    }
}
