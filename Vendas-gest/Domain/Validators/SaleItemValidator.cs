using Domain.Entities;
using Flunt.Validations;

namespace Domain.Validators
{
    class SaleItemValidator : IValidatable
    {
        private SaleItem  SaleItem { get; set; }
        public SaleItemValidator(SaleItem saleItem)
        {
            SaleItem = saleItem;
        }

        public void Validate()
        {
            SaleItem.AddNotifications(new Contract().Requires()
                .IsNotNull(SaleItem.Cart, "Cart", "Carrinho inválido")
                .IsNotNull(SaleItem.Product, "Product", "Produto inválido")
                .IsGreaterOrEqualsThan(SaleItem.Quantity, 0, "Quantity", "Quantidade inválida")
                );
        }
    }
}
