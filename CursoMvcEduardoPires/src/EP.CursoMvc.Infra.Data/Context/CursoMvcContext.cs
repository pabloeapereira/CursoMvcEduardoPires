using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Infra.Data.EntityConfig;

namespace EP.CursoMvc.Infra.Data.Context
{
    public class CursoMvcContext:DbContext
    {
        public CursoMvcContext()
            //:base("DefaultConnection")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}