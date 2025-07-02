using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class ProductTests
    {
        public readonly Product _validUser;
        public readonly Product _invalidUser;

        public ProductTests()
        {
            _validUser = new Product("Pura", "Agua mineral", 150, true);
            _invalidUser = new Product("", "Agua mineral", 0, false);
        }

        [TestMethod]
        public void Dado_um_produto_invalido_o_mesmo_deve_retorar_erro()
        {
            _invalidUser.Validate();
            Assert.AreEqual(false,_invalidUser.Valid);
        }
        [TestMethod]
        public void Dado_um_produto_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
            Assert.AreEqual(true, _validUser.Valid);
        }
        [TestMethod]
        public void Dado_um_produto_valido_com_0_de_estoque_deve_incrementar_10()
        {
            _validUser.AddStockQuantity(10);
            Assert.AreEqual(10,_validUser.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_valido_ao_incrementar_valores_negativos_deve_retornar_erro()
        {
            _validUser.AddStockQuantity(-10);
            Assert.AreEqual(false, _validUser.Valid);
        }
        [TestMethod]
        public void Dado_um_produto_valido_o_com_10_de_estoque_deve_decrementar_5()
        {
            _validUser.AddStockQuantity(10);
            _validUser.SubtractStockQuantity(5);
            Assert.AreEqual(5, _validUser.StockQuantity);
        }
        [TestMethod]
        public void Dado_um_produto_valido_com_10_de_estoque_ao_decrementar_11_deve_retornar_erro()
        {
            _validUser.AddStockQuantity(10);
            _validUser.SubtractStockQuantity(11);
            Assert.AreEqual(false, _validUser.Valid);
        }
        [TestMethod]
        public void Dado_um_produto_habilitado_o_mesmo_deve_ser_inabilitado()
        {
            _validUser.Enable();
            Assert.AreEqual(true, _validUser.Enabled);
        }
        [TestMethod]
        public void Dado_um_produto_inabilitado_o_mesmo_deve_ser_habilitado()
        {
            _validUser.Disable();
            Assert.AreEqual(false, _validUser.Enabled);
        }
    }
}
