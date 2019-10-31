using System;
using System.Linq;
using EP.CursoMvc.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Models
{
    [TestClass]
    public class ClienteTests
    {
        // AAA = Arrenge (Objeto a ser testado), Act (Ação a ser tomada para ser testado), Assert (Recurso a ser utilizado para verificar se o teste funcionou
        [TestMethod]
        public void Cliente_EhValido_DeveSerValido()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "04335098057",
                Email = "cliente@cliente.com.br",
                DataNascimento = new DateTime(1980,01,01)

            };

            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EhValido_NaoDeveSerValido()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "12345678901",
                Email = "cliente2cliente.com.br",
                DataNascimento = DateTime.Now

            };

            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um E-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro."));
        }
    }
}
