using DomainValidation.Validation;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specification.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnico = new ClienteDevePossuirCPFEmailUnicoSpecification(clienteRepository);

            base.Add("ClienteUnico", new Rule<Cliente>(clienteUnico, "Cliente com CPF ou E-mail já cadastrado."));
        }
    }
}