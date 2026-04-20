using Fiap.Api.FinancaFacil.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fiap.Api.FinancaFacil.Data.Factories;

public class OracleContextFactory : IDesignTimeDbContextFactory<OracleDatabaseContext>
{
    public OracleDatabaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<OracleDatabaseContext>()
            .UseOracle(connectionString, o => o.MigrationsAssembly(typeof(OracleDatabaseContext).Assembly.FullName))
            .Options;

        return new OracleDatabaseContext(options);
    }
}