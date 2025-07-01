using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class ProductTests
    {
        public readonly Product _Valid_Product;
        public readonly Product _Invalid_Product;

        public ProductTests()
        {
            _Valid_Product = new Product("Pura", "Agua mineral", 150, true);
            _Invalid_Product = new Product("", "Agua mineral", 0, false);
        }

        [TestMethod]
        public void Dado_um_produto_invalido_o_mesmo_deve_retorar_erro()
        {
            Assert.AreEqual(false,_Invalid_Product.Validate().IsValid);
        }
        [TestMethod]
        public void Dado_um_produto_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
            Assert.AreEqual(true, _Valid_Product.Validate().IsValid);
        }
        [TestMethod]
        public void Dado_um_produto_valido_com_0_de_estoque_deve_incrementar_10()
        {
            _Valid_Product.AddStockQuantity(10);
            Assert.AreEqual(10,_Valid_Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_com_10_de_estoque_ao_incrementar_valores_negativos_nao_deve_refletir()
        {
            _Valid_Product.AddStockQuantity(10);
            _Valid_Product.AddStockQuantity(-10);
            Assert.AreEqual(10, _Valid_Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_valido_o_com_10_de_estoque_deve_decrementar_5()
        {
            _Valid_Product.AddStockQuantity(10);
            _Valid_Product.SubtractStockQuantity(5);
            Assert.AreEqual(5, _Valid_Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_valido_o_com_10_de_estoque_ao_decrementar_11_nao_deve_refletir()
        {
            _Valid_Product.AddStockQuantity(10);
            _Valid_Product.SubtractStockQuantity(11);
            Assert.AreEqual(10, _Valid_Product.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_habilitado_o_mesmo_deve_ser_inabilitado()
        {
            _Valid_Product.Enable();
            Assert.AreEqual(true, _Valid_Product.Enabled);
        }
        [TestMethod]
        public void Dado_um_produto_inabilitado_o_mesmo_deve_ser_habilitado()
        {
            _Valid_Product.Disable();
            Assert.AreEqual(false, _Valid_Product.Enabled);
        }
    }
}
