using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    //FluentAPI
    public class ClienteConfig:EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);
            //HasKey(c => new {c.Id, c.CPF});

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index",new IndexAnnotation(
                    new IndexAttribute("IX_CPF"){IsUnique = true}));

            Property(c => c.Email)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired();
            Property(c => c.Ativo)
                .IsRequired();
            Property(c => c.Excluido)
                .IsRequired();
            Ignore(c => c.ValidationResult);

            ToTable("Clientes");
        }
    }
}