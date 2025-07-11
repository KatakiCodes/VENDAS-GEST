using Domain.Enums;
using Domain.Validation;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Cart : Entity
    {
        public ECartState State { get; private set; }
        private List<SaleItem> SaleItems { get; set; }
        public decimal Total { get; set; }
        public Cart()
        {
            State = ECartState.mounting;
            SaleItems = new List<SaleItem>();
            Total = 0;
        }
        public void AddItem(SaleItem saleItem)
        {
            DomainValidationExeption.When((saleItem is null), "Item de venda inválido");
            SaleItems.Add(saleItem);
            Total += saleItem.Total;
        }
        public void IncrementItemQuantity(SaleItem item, int quantity)
        {
            var findItem = this.SaleItems.Find(x => x.Id == item.Id);
            if (findItem != null)
            {
                Total -= findItem.Total;
                findItem.AddQuantity(quantity);
                Total += findItem.Total;
            }
        }
        public void DecrementItemQuantity(SaleItem item, int quantity)
        {
            var findItem = this.SaleItems.Find(x => x.Id == item.Id);
            if (findItem != null)
            {
                Total -= findItem.Total;
                findItem.SubtractQuantity(quantity);
                Total += findItem.Total;
            }
        }
        public void RemoveItem(SaleItem saleItem)
        {
            if (SaleItems.Find(item => item.Id == saleItem.Id) != null)
            {
                SaleItems.Remove(saleItem);
                Total -= saleItem.Total;
            }
            else
                throw new DomainValidationExeption("Item de venda não localizado");
        }
        public void Clear()
        {
            SaleItems.Clear();
        }
        public IEnumerable<SaleItem> ShowItems()
        {
            return SaleItems.AsReadOnly();
        }
        public void Finish()
        {
            if (this.Total > 0)
                State = ECartState.finished;
            else
                throw new DomainValidationExeption("Não é possível finalizar uma venda vazia");
        }
        public void Cancel()
        {
            if (State == ECartState.finished)
                State = ECartState.returned;
            else
                throw new DomainValidationExeption("Não é possível cancelar uma venda não efetuada");
        }
    }
}
