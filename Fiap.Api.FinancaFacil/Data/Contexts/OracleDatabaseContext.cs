using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Contexts;

public class OracleDatabaseContext : DatabaseContext
{
    public OracleDatabaseContext(DbContextOptions<OracleDatabaseContext> options) 
        : base(options) { }
}