using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ConsoleRpgEntities.Helpers;

namespace ConsoleRpgEntities.Data
{
    public class GameContextFactory : IDesignTimeDbContextFactory<GameContext>
    {
        public GameContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = ConfigurationHelper.GetConfiguration();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DbConnection");

            // Build DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<GameContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Create and return the context
            return new GameContext(optionsBuilder.Options);
        }
    }
}