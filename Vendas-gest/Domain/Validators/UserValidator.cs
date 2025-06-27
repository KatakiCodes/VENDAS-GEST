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
            RuleFor(user => user.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(user => user.Password).NotEmpty().NotNull().MinimumLength(6);
        }
    }
}
