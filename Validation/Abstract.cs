using Validation.Interfaces;

namespace Validation
{
    public abstract class Abstract : IValidator
    {
        protected dynamic Input;
        public bool Validate(dynamic input)
        {
            Input = input;
            return IsValid();
        }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}

