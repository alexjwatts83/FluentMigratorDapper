using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDapper.WebUI.Extensions
{
    public static class StartupSpaServicesExtensions
    {
        public static IServiceCollection AddSpaServices(this IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return services;
        }
    }
}
