using System;
using EP.CursoMvc.Domain.Models;


namespace EP.CursoMvc.Domain.Interfaces.Services
{
    public interface IClienteService:IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}
