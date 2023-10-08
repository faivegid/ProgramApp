using AutoFixture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProgramApp.AppService;
using ProgramApp.Domain.EfCore.UnitOfWorks;
using ProgramApp.Shared;

namespace ProgramApp.Test
{
    public class BaseTest
    {
        protected Mock<IUnitOfWork> unitOfWorkMock;
        protected Fixture fixture;
        protected ServiceCollection services;
        private ServiceProvider serviceProvider;

        public virtual void Initialize()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            fixture = new Fixture();
            services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);
            PostInitialize(config);
        }

        protected void PostInitialize(IConfiguration config)
        {
            services.AddSingleton(unitOfWorkMock.Object);
            services.ConfigureSharedLibrary(config);
            services.ConfigureAppServices();
            services.AddDistributedMemoryCache();
            services.AddAutoMapper(typeof(MappingProfiles));

            serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
