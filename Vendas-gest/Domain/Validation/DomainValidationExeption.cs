using System;
namespace Domain.Validation
{
    public class DomainValidationExeption : Exception
    {
        public DomainValidationExeption(string error) : base(error)
        {}
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidationExeption(error);
        }
    }
}
