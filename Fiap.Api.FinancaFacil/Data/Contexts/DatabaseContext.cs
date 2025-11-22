using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<ExampleModel> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExampleModel>(entity =>
            {
                entity.ToTable("Example");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique(); 
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        
        protected DatabaseContext()
        { }
    }
}
