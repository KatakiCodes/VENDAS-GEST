using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Enums;
using Domain.Validators;
using FluentValidation.Results;

namespace Vendas_Gest.Tests.Entities.Tests
{
    [TestClass]
    public class UserTests
    {
        private readonly User Invalid_User;
        private readonly User Valid_User;
        private UserValidator Validator;
        public UserTests()
        {
            Valid_User = new User("Nelson Dos Santos", "123456", EUserRole.Administrator, true);
            Invalid_User = new User("", "12345", EUserRole.Administrator, true);
            Validator = new UserValidator();
        }

        [TestMethod]
        public void Dados_um_utilizador_invalido_o_mesmo_deve_retornar_em_erro()
        {
            var validationResult = Validator.Validate(Invalid_User);
            Assert.AreEqual(false, validationResult.IsValid);
        }

        [TestMethod]
        public void Dados_um_utilizador_valido_o_mesmo_deve_ser_criado_com_sucesso()
        {
            var validationResult = Validator.Validate(Valid_User);
            Assert.AreEqual(true, validationResult.IsValid);
        }

        [TestMethod]
        public void Dados_um_utilizador_habilitado_o_mesmo_deve_ser_marcado_como_inabilitado()
        {
            Valid_User.Enable();
            Assert.AreEqual(true, Valid_User.Enabled);
        }

        [TestMethod]
        public void Dados_um_utilizador_inabilitado_o_mesmo_deve_ser_marcado_como_inabilitado()
        {
            Valid_User.Disable();
            Assert.AreEqual(false, Valid_User.Enabled);
        }
    }
}
