using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudSalesSystem.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureMediator();
            services.AddMapsterProfiles();
        }

        private static void AddMapsterProfiles(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
            // register the mapper as Singleton service for my application
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);
        }

        private static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
                //toDo
                //configuration.AddOpenBehavior(typeof(LoggingPipeLineBehavior<,>));
                //configuration.AddOpenBehavior(typeof(ValidationPipeLineBehaviour<,>));

            });
        }
    }
}
