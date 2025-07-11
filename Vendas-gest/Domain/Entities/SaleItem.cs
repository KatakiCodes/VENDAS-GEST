using Domain.Validation;
using System;

namespace Domain.Entities
{
    public class SaleItem : Entity
    {
        public SaleItem(Cart cart, Product product)
        {
            ValidateDomain(cart, product);
        }
        //Construtor para atualização
        public SaleItem(Guid id, Cart cart, Product product)
        {
            ValidateDomain(cart, product);
            Id = id;
        }

        public Cart Cart { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }

        public void AddQuantity(int quantity)
        {
            Product.SubtractStockQuantity(quantity);
            Quantity += quantity;
            Total += (Product.Price * quantity);
        }
        public void SubtractQuantity(int quantity)
        {
            DomainValidationExeption.When((quantity <= 0 || quantity > Quantity), "Quantidade inválida");
            Product.AddStockQuantity(quantity);
            Quantity -= quantity;
            Total -= (Product.Price * quantity);
        }


        public void ValidateDomain(Cart cart, Product product)
        {
            DomainValidationExeption.When((cart is null), "Carrinho inválido");
            DomainValidationExeption.When((product is null), "Produto inválido");
            Cart = cart;
            Product = product;
        }
    }
}
