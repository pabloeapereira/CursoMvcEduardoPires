using System;
using System.Collections.Generic;
using EP.CursoMvc.Domain.Validations.Clientes;

namespace EP.CursoMvc.Domain.Models
{
    public class Cliente:Entity
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }


        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public void Excluir()
        {
            Ativo = false;
            Excluido = true;
        }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        /*
         * Validação Manual
         * Extension Methods de validação
         * Padrão Specification - DomainValidation
         * FluentValidator
         */
        public override bool EhValido()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}