using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fiap.Api.FinancaFacil.Data.Contexts
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseOracle(
                "User Id=system;Password=123456;Data Source=localhost:1521/FREEPDB1"
            );

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}