
using CloudSalesSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CloudSalesSystem.Infrastructure.Configuration;

public class DatabaseInitializer(
        AppDbContext _context,
        ILogger<DatabaseInitializer> _logger) : IDatabaseInitializer
{
    public async Task Initialize()
    {
        try
        {
            // Check if the database exists
            bool databaseExists = await _context.Database.CanConnectAsync();

            if (!databaseExists)
            {
                // Database doesn't exist, create it and apply migrations
                await _context.Database.MigrateAsync();
            }
            else
            {
                // Database exists, apply any pending migrations
                await _context.Database.EnsureCreatedAsync(); // EnsureCreatedAsync won't try to recreate if database already exists
            }
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log the error)
            _logger.LogError($"Error occurred during database initialization: {ex.Message}");
        }
    }
}
