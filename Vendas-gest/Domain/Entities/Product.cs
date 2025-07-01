using Domain.Contracts;
using Domain.Validators;
using FluentValidation.Results;

namespace Domain.Entities
{
    public class Product : Entity, IValidateble
    {
        public Product(string name, string description, decimal price, bool enabled)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = 0;
            Enabled = enabled;
            _ProductValidator = new ProductValidator();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool Enabled { get; private set; }
        private readonly ProductValidator _ProductValidator;

        public void AddStockQuantity(int value)
        {
            if (value > 0)
                StockQuantity += value;
        }

        public void SubtractStockQuantity(int value)
        {
            if (value <= StockQuantity)
                StockQuantity -= value;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public ValidationResult Validate()
        {
            return _ProductValidator.Validate(this);
        }
    }
}
