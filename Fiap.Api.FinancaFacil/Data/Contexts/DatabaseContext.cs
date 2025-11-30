using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        
        public virtual DbSet<RendaModel> Rendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("tb_usuario");

                entity.HasKey(e => e.IdUsuario);
            });

            modelBuilder.Entity<RendaModel>(entity =>
            {
                entity.ToTable("tb_renda");
                
                entity.HasKey(e => e.IdRenda);

                entity
                    .Property(r => r.VlRenda)
                    .HasColumnType("decimal(18,2)");
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        
        protected DatabaseContext()
        { }
    }
}
