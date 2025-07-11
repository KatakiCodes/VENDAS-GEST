using Domain.Enums;
using Domain.Validation;
using System;

namespace Domain.Entities
{
    public class Sale : Entity
    {
        public Sale(User user,Cart cart)
        {
            ValidateDomain(user, cart);
        }

        public Cart Cart { get; private set; }
        public User User { get; private set; }
        public DateTime Date { get; private set; }
        public ESaleState State { get; private set; }

        public void Finish()
        {
            if(Cart.State == ECartState.finished)
                State = ESaleState.finished;
            else
            {
                Cart.Finish();
                State = ESaleState.finished;
            }
        }
        public void Cancel()
        {
            if (Cart.State == ECartState.returned)
                State = ESaleState.canceled;
            else
            {
                Cart.Cancel();
                State = ESaleState.canceled;
            }
        }

        public void ValidateDomain(User user, Cart cart)
        {
            DomainValidationExeption.When((user is null) || !(user.Enabled), "Utilizador inválido");
            DomainValidationExeption.When((cart is null), "Carrinho inválido");
            User = user;
            Cart = cart;
        }
    }
}
