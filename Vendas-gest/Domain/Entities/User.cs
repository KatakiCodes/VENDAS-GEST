using Domain.Enums;
using Domain.Interfaces.Validators;
using Domain.Validators;
using FluentValidation.Results;

namespace Domain.Entities
{
    public class User : Entity, IValidateble
    {
        public User(string name, string password, EUserRole role, bool enabled)
        {
            Name = name;
            Password = password;
            Role = role;
            Enabled = enabled;
            _UserValidator = new UserValidator();
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Enabled { get; private set; }
        private readonly UserValidator _UserValidator;

        public void Enable()
        {
            this.Enabled = true;
        }
        public void Disable()
        {
            this.Enabled = false;
        }
        public ValidationResult Validate()
        {
            return _UserValidator.Validate(this);
        }
    }
}