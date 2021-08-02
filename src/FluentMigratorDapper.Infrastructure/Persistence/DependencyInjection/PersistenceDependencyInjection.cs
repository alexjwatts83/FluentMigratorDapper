using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;
using FluentMigratorDapper.Infrastructure.Persistence.Repositories;
using FluentMigratorDapper.Infrastructure.Persistence.RepositoryScripts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDapper.Infrastructure.Persistence.DependencyInjection
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));
            services.AddTransient<ILocationGenericCrudRepositoryScripts, LocationGenericCrudRepositoryScripts>();
            services.AddTransient<IMoviesGenericCrudRepositoryScripts, MoviesGenericCrudRepositoryScripts>();
            services.AddTransient<ITagsGenericCrudRepositoryScripts, TagsGenericCrudRepositoryScripts>();
            services.AddScoped(typeof(IGenericCrudRepository<,>), typeof(GenericCrudRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
