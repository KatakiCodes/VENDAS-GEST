using FluentValidation.Results;

namespace Domain.Interfaces.Validators
{
    interface IValidateble
    {
        ValidationResult Validate();
    }
}
