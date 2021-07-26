using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public static class PersistenceStartupInjections
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionStrings = config.GetSection(ConnectionStringSettings.Section);
            //services.Configure<ConnectionStringSettings>(ConnectionStringSettings. config.GetSection(""));
            //services.Configure<ConnectionStringSettings>(config.GetSection(ConnectionStringSettings.Section));

            return services;
        }
    }
}
