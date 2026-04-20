using Fiap.Api.FinancaFacil.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fiap.Api.FinancaFacil.Data.Factories;

public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresDatabaseContext>
{
    public PostgresDatabaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<PostgresDatabaseContext>()
            .UseNpgsql(connectionString, o => o.MigrationsAssembly(typeof(PostgresDatabaseContext).Assembly.FullName))
            .Options;

        return new PostgresDatabaseContext(options);
    }
}