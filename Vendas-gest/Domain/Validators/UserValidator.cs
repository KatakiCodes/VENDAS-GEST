using System.Collections.Generic;
using Domain.Entities;

using Flunt.Validations;

namespace Domain.Validators
{
    public class UserValidator : IValidatable
    {
        private readonly User _user;
        public UserValidator(User user)
        {
            _user = user;
        }

        public void Validate()
        {
            _user.AddNotifications(new Contract().Requires()
                .IsNotNull(_user.Name, "Name", "Nome inválido!")
                .IsNotNull(_user.Password, "Password", "Palavra-passe inválida!")
                .IsNotNull(_user.Role, "Role", "Função inválida!"));
        }
    }
}
