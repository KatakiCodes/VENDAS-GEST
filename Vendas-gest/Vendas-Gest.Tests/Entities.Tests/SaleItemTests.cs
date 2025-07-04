using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class SaleItemTests
    {
        private readonly Cart _cart;
        private readonly Product _product;
        private readonly SaleItem _validSaleItem;
        private readonly SaleItem _invalidSaleItem;

        public SaleItemTests()
        {
            _cart = new Cart();
            _product = new Product("product1","prodDesc",1200,true);
            _validSaleItem = new SaleItem(_cart, _product);
            _invalidSaleItem = new SaleItem(_cart, null);
            _product.AddStockQuantity(10);
        }

        [TestMethod]
        public void Dado_um_item_invalido_o_mesmo_deve_retornar_erro()
        {
            _invalidSaleItem.Validate();
            Assert.AreEqual(true, _invalidSaleItem.Invalid);
        }
        [TestMethod]
        public void Dado_um_item_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
            _validSaleItem.Validate();
            Assert.AreEqual(true, _validSaleItem.Valid);
        }
        [TestMethod]
        public void Dado_um_item_valido_nao_deve_ser_incrementado_quantidade_menor_ou_igual_a_zero()
        {
            _validSaleItem.AddQuantity(-20);
            Assert.AreEqual(false, _validSaleItem.Valid);
            Assert.AreEqual(0, _validSaleItem.Quantity);
            Assert.AreEqual(10, _validSaleItem.Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_item_valido_nao_deve_ser_incrementado_quantidade_maior_que_o_estoque_do_produto()
        {
            _validSaleItem.AddQuantity(120);
            Assert.AreEqual(false, _validSaleItem.Valid);
            Assert.AreEqual(0, _validSaleItem.Quantity);
            Assert.AreEqual(10, _validSaleItem.Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_item_valido_deve_ser_incrementado_3_na_sua_quantidade()
        {
            _validSaleItem.AddQuantity(3);
            Assert.AreEqual(3, _validSaleItem.Quantity);
            Assert.AreEqual(7, _validSaleItem.Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_item_valido_nao_deve_ser_decrementado_valores_abaixo_de_zero_na_sua_quantidade()
        {
            _validSaleItem.SubtractQuantity(-3);
            Assert.AreEqual(false, _validSaleItem.Valid);
            Assert.AreEqual(0, _validSaleItem.Quantity);
            Assert.AreEqual(10, _validSaleItem.Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_item_valido_nao_deve_ser_decrementado_valores_acima_sua_quantidade_existente()
        {
            _validSaleItem.AddQuantity(6);
            _validSaleItem.SubtractQuantity(10);
            Assert.AreEqual(false, _validSaleItem.Valid);
            Assert.AreEqual(6, _validSaleItem.Quantity);
            Assert.AreEqual(4, _validSaleItem.Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_item_valido_deve_ser_decrementado_3_na_sua_quantidade()
        {
            _validSaleItem.AddQuantity(6);
            _validSaleItem.SubtractQuantity(3);
            Assert.AreEqual(3, _validSaleItem.Quantity);
            Assert.AreEqual(7, _validSaleItem.Product.StockQuantity);
        }
    }
}
