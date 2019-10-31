using System.Linq;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Specification.Clientes
{
    internal class ClienteDevePossuirCPFEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterClienteUnico(cliente) == null;
        }
    }
}