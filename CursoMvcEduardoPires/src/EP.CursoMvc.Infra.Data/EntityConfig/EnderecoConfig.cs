using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);
            //HasKey(c => new {c.Id, c.CPF});

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Bairro).IsRequired().HasMaxLength(50);
            Property(e => e.CEP).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(e => e.Complemento).HasMaxLength(100);

            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            Ignore(c => c.ValidationResult);

            //HasOptional(e => e.Cliente)
            //    .WithMany(c => c.Enderecos)
            //    .HasForeignKey(e => e.ClienteId);


            ToTable("Enderecos");
        }
    }
}