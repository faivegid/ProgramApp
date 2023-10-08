using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramApp.Shared.Base;
using ProgramApp.Shared.Responses;

namespace ProgramApp
{
    public static class ServiceConfigurationExtension
    {
        /// <summary>
        /// Configures how validation is handle for request body
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(x => x.Key, x => string.Join(Environment.NewLine, x.Value.Errors.Select(e => e.ErrorMessage)));

                    var response = ApiResponse.Error("Validation error(s) occureed", errorObject: errors);
                    return new BadRequestObjectResult(response);
                };
            });
        }

        /// <summary>
        /// Add configuration for dbs
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddDb(this IServiceCollection services, IConfiguration config)
        {
            var settings = config.GetSection(nameof(CosmosSettings)).Get<CosmosSettings>();
            services.AddDbContext<Domain.EfCore.AppContext>(opt =>
            {
                opt.UseCosmos(settings.EndpointUrl, settings.PrimaryKey, settings.DatabaseId);

                opt.EnableSensitiveDataLogging(); 
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });
        }
    }
}
