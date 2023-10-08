using Microsoft.Extensions.DependencyInjection;
using ProgramApp.Domain.EfCore.UnitOfWorks;

namespace ProgramApp.Domain
{
    public static class DomainModule
    {
        /// <summary>
        /// Configures dependency injection and configuration for domain
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
