using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Enums;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class UserTests
    {
        private readonly User _invalidUser;
        private readonly User _validUser;
        public UserTests()
        {
            _validUser = new User("Nelson Dos Santos", "123456", EUserRole.Administrator, true);
            _invalidUser = new User(null, "12345", EUserRole.Administrator, true);
        }

        [TestMethod]
        public void Dados_um_utilizador_invalido_o_mesmo_deve_retornar_em_erro()
        {
            _invalidUser.Validate();
            Assert.AreEqual(false, _invalidUser.Valid);
        }

        [TestMethod]
        public void Dados_um_utilizador_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
           _validUser.Validate();
            Assert.AreEqual(true, _validUser.Valid);
        }

        [TestMethod]
        public void Dados_um_utilizador_habilitado_o_mesmo_deve_ser_marcado_como_desabilitado()
        {
            _validUser.Disable();
            Assert.AreEqual(false, _validUser.Enabled);
        }

        [TestMethod]
        public void Dados_um_utilizador_desabilitado_o_mesmo_deve_ser_marcado_como_abilitado()
        {
            _validUser.Enable();
            Assert.AreEqual(true, _validUser.Enabled);
        }
    }
}
