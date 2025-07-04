using Domain.Validators;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Domain.Entities
{
    public class SaleItem : Entity, IValidatable
    {
        public SaleItem(Cart cart, Product product)
        {
            Cart = cart;
            Product = product;
            Quantity = 0;
            _saleItemValidator = new SaleItemValidator(this);
        }

        public Cart Cart { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        private readonly SaleItemValidator _saleItemValidator;

        public void AddQuantity(int quantity)
        {
            Product.SubtractStockQuantity(quantity);
            if (Product.Valid is false)
                this.AddNotifications(Product.Notifications);
            else
                Quantity += quantity;
        }
        public void SubtractQuantity(int quantity)
        {
            if (Product.Valid is false)
                this.AddNotifications(Product.Notifications);
            else if(quantity <= 0 || quantity > Quantity)
                this.AddNotification(new Notification($"{quantity}","Não foi possível subtrair esta quantidade!"));
            else
            {
                Product.AddStockQuantity(quantity);
                Quantity -= quantity;
            }
        }


        public void Validate()
        {
            _saleItemValidator.Validate();
        }
    }
}
