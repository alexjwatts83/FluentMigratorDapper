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
            var options = GetFluentMigratorOptions(host);

            var serviceProvider = PersistenceDbMigrations.CreateServices(options.DbConnectionString, options.Tags);

            PersistenceDbMigrations.EnsureDatabase(options.MasterDb, options.MainDbName);

            // Put the database update into a scope to ensure that all resources will be disposed.
            using var scope = serviceProvider.CreateScope();

            PersistenceDbMigrations.UpdateDatabase(scope.ServiceProvider);
        }

        private static FluentMigratorOptions GetFluentMigratorOptions(IHost host)
        {
            var options = new FluentMigratorOptions();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                options.DbConnectionString = config.GetConnectionString("Database");
                options.MasterDb = config.GetConnectionString("Master");
                options.MainDbName = config.GetSection(FluentMigratorSettings.MainDbName).Value;
                options.TagsRaw = config.GetSection(FluentMigratorSettings.Tags).Value;
            }
            return options;
        }
    }

    internal class FluentMigratorOptions
    {
        public FluentMigratorOptions()
        {
            TagsRaw = "Development";
        }
        public string DbConnectionString { get; set; }
        public string MasterDb { get; set; }
        public string MainDbName { get; set; }
        public string TagsRaw { get; set; }
        public string[] Tags => TagsRaw.Split(",");
    }
}
