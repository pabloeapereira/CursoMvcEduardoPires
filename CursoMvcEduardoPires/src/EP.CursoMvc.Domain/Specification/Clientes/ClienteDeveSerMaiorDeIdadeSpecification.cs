using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Specification.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification:ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 21;
        }
    }
}
