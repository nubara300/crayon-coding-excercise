using CloudSalesSystem.Domain.Interfaces.Repositories;

namespace CloudSalesSystem.API.Extensions;

public static class ApplicationExtensions
{
    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        try
        {
            IDatabaseInitializer databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
            await databaseInitializer.Initialize();
        }
        catch
        {
            throw;
        }
    }
}
