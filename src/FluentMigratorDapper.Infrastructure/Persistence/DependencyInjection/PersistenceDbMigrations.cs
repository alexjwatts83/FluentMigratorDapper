using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigratorDapper.Infrastructure.Persistence.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDapper.Infrastructure.Persistence.DependencyInjection
{
    public static class PersistenceDbMigrations
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        public static IServiceProvider CreateServices(string dbConnectionString, string[] tags)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .Configure<AssemblySourceOptions>(x => x.AssemblyNames = new[] { typeof(AddLocations).Assembly.GetName().Name })
                .ConfigureRunner(rb => rb
                    // Add SQL Server support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(dbConnectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(AddLocations).Assembly)
                        .For.Migrations()
                        .For.EmbeddedResources())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .Configure<FluentMigratorLoggerOptions>(options =>
                {
                    options.ShowSql = true;
                    options.ShowElapsedTime = true;
                })
                .Configure<RunnerOptions>(opt =>
                {
                    opt.Tags = tags;
                })
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            if (runner.HasMigrationsToApplyDown(1))
            {
                runner.MigrateDown(1);
            }

            if (runner.HasMigrationsToApplyUp())
            {
                runner.MigrateUp();
            }
            runner.ListMigrations();
        }
    }
}
