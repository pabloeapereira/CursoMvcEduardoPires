using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            //return Buscar(c => c.Ativo && !c.Excluido);
            var sql = @"SELECT * FROM Clientes c " +
                      "WHERE c.Excluido = 0 AND c.Ativo = 1";
            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Excluir();
            Atualizar(cliente);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Clientes c 
                      LEFT JOIN Enderecos e 
                      ON c.Id = e.ClienteId 
                      WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            //throw new Exception("THE TRETA HAS BEEN PLANTED");
            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new {uid = id}).FirstOrDefault();
        }
    }
}