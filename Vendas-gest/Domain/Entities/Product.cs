using Domain.Validation;
using System;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, string description, decimal price, bool enabled)
        {
            ValidateDomain(name, description, price, enabled);
        }
        //Construto para atuaçização
        public Product(Guid id, string name, string description, decimal price, bool enabled)
        {
            ValidateDomain(name, description, price, enabled);
            Id = id;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool Enabled { get; private set; }

        public void AddStockQuantity(int quantity)
        {
            DomainValidationExeption.When((quantity <= 0), "Quantidade inválida");
            StockQuantity += quantity;
        }

        public void SubtractStockQuantity(int quantity)
        {
            DomainValidationExeption.When((quantity <= 0), "Quantidade inválida");
            DomainValidationExeption.When((quantity > StockQuantity), "Quantidade superior a quantidade em estoque");
            StockQuantity -= quantity;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void ValidateDomain(string name, string description, decimal price, bool enabled)
        {
            DomainValidationExeption.When(string.IsNullOrEmpty(name), "O nome do produto não pode ser vazio ou nulo");
            DomainValidationExeption.When(string.IsNullOrEmpty(description), "A descrição do produto não pode ser vazia ou nula");
            DomainValidationExeption.When((price <= 0), "Preço do produto inválido");
            Name = name;
            Description = description;
            Price = price;
            Enabled = enabled;
        }

    }
}
