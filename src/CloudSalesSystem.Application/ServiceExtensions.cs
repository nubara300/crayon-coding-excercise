using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudSalesSystem.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureMediator();
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
