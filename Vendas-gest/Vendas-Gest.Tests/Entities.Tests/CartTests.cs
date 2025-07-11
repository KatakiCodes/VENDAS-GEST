using System;
using Domain.Entities;
using Domain.Enums;
using Domain.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class CartTests
    {
        private readonly Cart _Cart;
        private readonly SaleItem _validItem_1;
        private readonly SaleItem _validItem_2;
        private readonly SaleItem _invalidItem;
        private readonly Product _product_1;
        private readonly Product _product_2;

        public CartTests()
        {
            _Cart = new Cart();

            _product_1 = new Product("product1", "prodesc", 1000, true);
            _product_2 = new Product("product2", "prodesc", 500, true);
            _product_1.AddStockQuantity(10);
            _product_2.AddStockQuantity(10);

            _validItem_1 = new SaleItem(_Cart, _product_1);
            _validItem_2 = new SaleItem(_Cart, _product_2);
            _validItem_1.AddQuantity(2);
            _validItem_2.AddQuantity(2);

        }
        [TestMethod]
        public void Dado_um_cart_deve_ser_inicializado_com_sucesso()
        {
            Assert.AreEqual(ECartState.mounting, _Cart.State);
            Assert.AreEqual(0, _Cart.Total);
        }

        [TestMethod]
        public void Dado_um_cart_ao_adicionar_um_item_invalido_deve_retornar_erro()
        {
            Assert.ThrowsException<DomainValidationExeption>(() => _Cart.AddItem(_invalidItem), "Erro ao adicionar item de venda");
        }
        //Adicionar 2 itens de venda
        //Com 2 unidade em cada item de cada de venda
        [TestMethod]
        public void Dado_um_cart_deve_adicionar_2_itens_validos_refletindo_o_total_de_3000()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.AddItem(_validItem_2);
            Assert.AreEqual(3000, _Cart.Total);
        }
        [TestMethod]
        public void Dado_um_cart_deve_refletir_o_total_de_2500_ao_subtrair_uma_unidade_do_item_de_venda()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.AddItem(_validItem_2);

            _Cart.DecrementItemQuantity(_validItem_2, 1);

            Assert.AreEqual(2500, _Cart.Total);
        }
        [TestMethod]
        public void Dado_um_cart_deve_nao_refletir_o_total_ao_subtrair_uma_unidade_do_item_de_venda_negativa()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.AddItem(_validItem_2);
            Assert.AreEqual(3000, _Cart.Total);
            Assert.ThrowsException<DomainValidationExeption>(() => _Cart.DecrementItemQuantity(_validItem_1, -2), "Erro ao decrementar quantidade do item de venda");
        }
        [TestMethod]
        public void Dado_um_cart_deve_refletir_o_total_de_1000_ao_subtrair_um_item_de_venda()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.AddItem(_validItem_2);

            _Cart.RemoveItem(_validItem_1);

            Assert.AreEqual(1000, _Cart.Total);
        }
        [TestMethod]
        public void Dado_um_cart_vazio_nao_deve_ser_finalizado()
        {
            Assert.ThrowsException<DomainValidationExeption>(() => _Cart.Finish(), "Erro ao finalizar de venda");
            Assert.AreEqual(ECartState.mounting, _Cart.State);
        }
        [TestMethod]
        public void Dado_um_cart_inicializado_deve_ser_finalizado()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.Finish();
            Assert.AreEqual(ECartState.finished, _Cart.State);
        }
        [TestMethod]
        public void Dado_um_cart_inicializado_nao_deve_ser_cancelado()
        {
            _Cart.AddItem(_validItem_1);
            Assert.ThrowsException<DomainValidationExeption>(() => _Cart.Cancel(), "Erro ao cancelar de venda");
            Assert.AreEqual(ECartState.mounting, _Cart.State);
        }
        [TestMethod]
        public void Dado_um_cart_finalizado_deve_cancelado()
        {
            _Cart.AddItem(_validItem_1);
            _Cart.Finish();
            _Cart.Cancel();
            Assert.AreEqual(ECartState.returned, _Cart.State);
        }
    }
}
