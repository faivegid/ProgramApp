using Microsoft.Extensions.DependencyInjection;
using ProgramApp.AppService.ApplicationStages;
using ProgramApp.AppService.ApplicationTemplates;
using ProgramApp.AppService.Programs;

namespace ProgramApp.AppService
{
    public static class AppServiceModule
    {
        /// <summary>
        /// Configures dependency injection and configuration for appservices
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IProgramAppService, ProgramAppService>();
            services.AddScoped<IApplicationTemplateAppService, ApplicationTemplateAppService>();
            services.AddScoped<IApplicationStageAppService, ApplicationStageAppService>();
        }
    }
}
