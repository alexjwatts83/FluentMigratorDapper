using FluentMigratorDapper.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FluentMigratorDapper.WebApi
{
    internal static class RunDbMigrations
    {
        internal static void Run(IHost host)
        {
            // Run db Migrations
            var dbConnectionString = string.Empty;
            var masterDb = string.Empty;
            var mainDbName = string.Empty;
            var tagsRaw = string.Empty;
            var tags = new string[] { "Production" };
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                dbConnectionString = config.GetConnectionString("Database");
                masterDb = config.GetConnectionString("Master");
                mainDbName = config.GetSection(FluentMigratorSettings.MainDbName).Value;
                tagsRaw = config.GetSection(FluentMigratorSettings.Tags).Value;
                if (!string.IsNullOrEmpty(tagsRaw))
                {
                    tags = tagsRaw.Split(",");
                }
            }
            var serviceProvider = PersistenceDbMigrations.CreateServices(dbConnectionString, tags);

            PersistenceDbMigrations.EnsureDatabase(masterDb, mainDbName);

            // Put the database update into a scope to ensure that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                PersistenceDbMigrations.UpdateDatabase(scope.ServiceProvider);
            }
        }
    }
}
