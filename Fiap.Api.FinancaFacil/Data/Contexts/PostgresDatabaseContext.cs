using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Contexts;

public class PostgresDatabaseContext : DatabaseContext
{
    public PostgresDatabaseContext(DbContextOptions<PostgresDatabaseContext> options) 
        : base(options) { }
}