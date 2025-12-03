using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        
        public virtual DbSet<RendaModel> Rendas { get; set; }
        
        public virtual DbSet<DespesaModel> Despesas { get; set; }
        
        public virtual DbSet<CursoModel> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("tb_usuario");

                entity.HasKey(e => e.IdUsuario);

                entity.HasMany(e => e.Rendas)
                    .WithOne(r => r.Usuario)
                    .HasForeignKey(r => r.IdUsuario);
            });

            modelBuilder.Entity<RendaModel>(entity =>
            {
                entity.ToTable("tb_renda");
                
                entity.HasKey(e => e.IdRenda);

                entity
                    .Property(r => r.VlRenda)
                    .HasColumnType("decimal(18,2)");
            });
            
            modelBuilder.Entity<DespesaModel>(entity =>
            {
                entity.ToTable("tb_despesa");

                entity.HasKey(e => e.IdDespesa);

                entity
                    .Property(d => d.Valor)
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<CursoModel>(entity =>
            {
                entity.ToTable("tb_curso");

                entity.HasKey(e => e.Id);
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        
        protected DatabaseContext()
        { }
    }
}
