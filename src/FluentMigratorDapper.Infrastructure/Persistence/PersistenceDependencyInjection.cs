using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IApplicationBuilder ConfigureErrorUsing(this IApplicationBuilder app)
        {

            return app;
        }

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));

            services.AddTransient<ILocationsRepository, LocationsRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
