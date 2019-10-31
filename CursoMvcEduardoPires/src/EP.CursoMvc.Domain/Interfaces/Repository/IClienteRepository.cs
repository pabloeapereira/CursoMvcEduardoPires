using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Interfaces.Repository
{
    public interface IClienteRepository:IRepository<Cliente>, IRepositoryChange<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();

        Cliente ObterClienteUnico(Cliente cliente);
    }
}
