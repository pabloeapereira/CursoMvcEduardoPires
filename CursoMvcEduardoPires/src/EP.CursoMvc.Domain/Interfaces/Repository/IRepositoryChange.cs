using System;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Interfaces.Repository
{
    public interface IRepositoryChange<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}