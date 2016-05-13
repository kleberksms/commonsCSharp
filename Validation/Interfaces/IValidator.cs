using System.Security.Cryptography.X509Certificates;

namespace Validation.Interfaces
{
    public interface IValidator
    {
        bool Validate(dynamic input);

        bool IsValid();
    }
}
