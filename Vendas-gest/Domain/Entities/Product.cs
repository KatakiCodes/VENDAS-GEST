﻿
using Domain.Validators;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public class Product : Entity, IValidatable
    {
        public Product(string name, string description, decimal price, bool enabled)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = 0;
            Enabled = enabled;
            _productValidator = new ProductValidator(this);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool Enabled { get; private set; }

        private readonly ProductValidator _productValidator;

        public void AddStockQuantity(int quantity)
        {
            if (quantity <= 0)
                this.AddNotification(new Notification($"{quantity}", "Quantidade inválida"));
            else
                StockQuantity += quantity;
        }

        public void SubtractStockQuantity(int quantity)
        {
            if (quantity <= 0)
                this.AddNotification(new Notification($"{quantity}", "Quantidade inválida!"));
            else if (quantity > StockQuantity)
                this.AddNotification(new Notification($"{quantity}", "Valor superior a quantidade em estoque!"));
            else
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

        public void Validate()
        {
            _productValidator.Validate();
        }

    }
}
