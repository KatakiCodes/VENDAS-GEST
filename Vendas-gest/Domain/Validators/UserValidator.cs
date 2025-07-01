using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("O nome do utilizador não pode ser vazio!")
                .NotNull().WithMessage("O nome do utilizador não pode ser nulo!");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("A palavra-passe do utilizador não pode ser vazio!")
                .NotNull().WithMessage("A palavra-passe do utilizador não pode ser nula!");
        }
    }
}
