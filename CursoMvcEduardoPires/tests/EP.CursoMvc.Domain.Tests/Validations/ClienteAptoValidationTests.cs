using System.Linq;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Validations
{
    [TestClass]
    public class ClienteAptoValidationTests
    {
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "04335098057",
                Email = "teste@teste.com"
            };

            //Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterClienteUnico(cliente)).Return(null);
            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            //Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "04335098057",
                Email = "teste@teste.com"
            };

            //Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterClienteUnico(cliente)).Return(cliente);
            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            //Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message== "Cliente com CPF ou E-mail já cadastrado."));
        }
    }
}
