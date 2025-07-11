using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Enums;
using Domain.Validation;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class UserTests
    {
        private readonly User _validUser;
        public UserTests()
        {
            _validUser = new User("Nelson Dos Santos", "123456", EUserRole.Administrator, true);
        }

        [TestMethod]
        public void Dados_um_utilizador_invalido_o_mesmo_deve_retornar_em_erro()
        {
            Assert.ThrowsException<DomainValidationExeption>(() => new User(null, "12345", EUserRole.Administrator, true), "Erro ao criar o utilizador");
        }

        [TestMethod]
        public void Dados_um_utilizador_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
            Assert.AreEqual(false, (_validUser is null));
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
