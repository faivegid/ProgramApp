using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramApp.Shared.Base;

namespace ProgramApp.Shared
{
    public static class SharedModule
    {
        /// <summary>
        /// Configures dependency injection and configuration for shared library
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSharedLibrary(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(opt => config.GetSection(nameof(CosmosSettings)).Get<CosmosSettings>());
        }
    }
}
