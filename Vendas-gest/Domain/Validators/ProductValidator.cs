using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("O nome do produto não deve ser vazio!")
                .NotNull().WithMessage("O nome do produto não pode ser nulo!");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("A descrição do produto não pode ser vazio!")
                .NotNull().WithMessage("A descrição do produto não pode ser nula!");
            RuleFor(Product => Product.Price).GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero!")
                .NotNull().WithMessage("O preço do produto não pode ser nulo!");
        }
    }
}
