using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GEAP.Models
{

    public class GEAPDBContext : DbContext
    {

        public GEAPDBContext() : base("GEAPDBContext")
        {
        }

        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<ModeloVersao> ModelosVersao { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedoress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}