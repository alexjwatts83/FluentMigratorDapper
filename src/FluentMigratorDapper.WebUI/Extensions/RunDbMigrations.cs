using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentMigratorDapper.Infrastructure.Persistence;
namespace FluentMigratorDapper.WebUI
{
    internal static class RunDbMigrations
    {
        internal static void Run(IHost host)
        {
            // Run db Migrations
            var dbConnectionString = string.Empty;
            var masterDb = string.Empty;
            var mainDbName = string.Empty;
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                dbConnectionString = config.GetConnectionString("Database");
                masterDb = config.GetConnectionString("Master");
                mainDbName = config.GetConnectionString("MainDbName");
            }
            var serviceProvider = PersistenceDbMigrations.CreateServices(dbConnectionString);

            PersistenceDbMigrations.EnsureDatabase(masterDb, mainDbName);

            // Put the database update into a scope to ensure that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                PersistenceDbMigrations.UpdateDatabase(scope.ServiceProvider);
            }
        }
    }
}
