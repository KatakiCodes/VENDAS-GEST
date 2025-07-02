using Domain.Entities;
using Flunt.Validations;

namespace Domain.Validators
{
    class ProductValidator : IValidatable
    {
        private readonly Product _product;

        public ProductValidator(Product product)
        {
            this._product = product;
        }

        public void Validate()
        {
            _product.AddNotifications(new Contract().Requires()
                .IsNotNull(_product.Name, "Name", "Nome inválido!")
                .IsNotNull(_product.Description, "Description", "Descrição inválida!")
                .IsGreaterThan(_product.Price, 0, "Price", "Preço inválido"));
        }
    }
}
