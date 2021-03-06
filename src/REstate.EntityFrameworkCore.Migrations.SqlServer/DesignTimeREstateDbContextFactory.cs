using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using REstate.Engine.Repositories.EntityFrameworkCore;

namespace REstate.EntityFrameworkCore.Migrations.SqlServer
{
    /// <summary>
    /// This is used to generate migrations. NOT intended to be used by consumers.
    /// </summary>
    internal class DesignTimeREstateDbContextFactory : IDesignTimeDbContextFactory<REstateDbContext>
    {
        public REstateDbContext CreateDbContext(string[] args)
        {
            return new REstateDbContextFactory(new DbContextOptionsBuilder<REstateDbContext>()
                    .UseSqlServer(
                        "Server=(localdb)\\mssqllocaldb;Database=REstate;Trusted_Connection=True;MultipleActiveResultSets=true",
                        b => b
                            .MigrationsAssembly(GetType().Assembly.FullName)
                            .EnableRetryOnFailure())
                    .Options)
                .CreateContext();
        }
    }
}