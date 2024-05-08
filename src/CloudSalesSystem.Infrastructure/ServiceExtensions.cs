using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CloudSalesSystem.Application.CloudComputingService;
using Polly;
using Polly.Extensions.Http;
using CloudSalesSystem.Infrastructure.CloudComputingProviderServices;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CloudSalesSystem.Domain.Interfaces.Cache;
using CloudSalesSystem.Infrastructure.Caching;
using CloudSalesSystem.Domain.Interfaces.ServiceContext;
using CloudSalesSystem.Infrastructure.ServiceContexts;

namespace CloudSalesSystem.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureContext(config);
        services.ConfigureCCPHttpClient(config);
        services.ConfigureCaching(config);

        // Add services here
        services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
        services.AddScoped<IServiceContext, ServiceContext>();

        services.AddTransient<ICloudComputingProviderService, CloudComputingProviderService>();
    }

    public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void ConfigureCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICache, Cache>();
    }

    private static void ConfigureCCPHttpClient(this IServiceCollection services, IConfiguration config)
    {
        string baseUrl = config.GetSection("CloudProviderAPI").Value ?? string.Empty;
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new ArgumentException("Cloud computing service URL is not set! Add it to the config file.");
        }
        services.AddHttpClient(nameof(CloudComputingProviderService), httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            //httpClient.Timeout = TimeSpan.FromSeconds(20);
        })
        .AddPolicyHandler(GetRetryPolicy())
        .AddPolicyHandler(GetCircuitBreakerPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() => HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(20));

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() => HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(20));
}
