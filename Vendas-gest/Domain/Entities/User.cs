using Domain.Enums;
using Domain.Validators;
using Flunt.Validations;

namespace Domain.Entities
{
    public class User : Entity, IValidatable
    {
        public User(string name, string password, EUserRole role, bool enabled)
        {
            Name = name;
            Password = password;
            Role = role;
            Enabled = enabled;
            _userValidator = new UserValidator(this);
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Enabled { get; private set; }

        private readonly UserValidator _userValidator;

        public void Enable()
        {
            this.Enabled = true;
        }
        public void Disable()
        {
            this.Enabled = false;
        }
        public void Validate()
        {
            _userValidator.Validate();
        }
    }
}