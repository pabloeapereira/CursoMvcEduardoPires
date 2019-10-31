using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specification.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Specifications
{
    [TestClass]
    public class CpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_IsSatisfied_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "04335098057"
            };

            //Act
            var specReturn = new ClienteDeveTerCpfValidoSpecification().IsSatisfiedBy(cliente);

            //Assert
            Assert.IsTrue(specReturn);
        }

        [TestMethod]
        public void CpfSpecification_IsSatisfied_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "04335098777"
            };

            //Act
            var specReturn = new ClienteDeveTerCpfValidoSpecification().IsSatisfiedBy(cliente);

            //Assert
            Assert.IsFalse(specReturn);
        }
    }
}