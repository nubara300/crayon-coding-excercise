
namespace CloudSalesSystem.Domain.Interfaces.Cache;

/// <summary>
/// Cache interaface behind who we can add any caching mechanism
/// </summary>
public interface ICache
{
    // Add an item to the cache with a specified key and expiration time
    Task AddAsync<T>(string key, T value, TimeSpan expiration);

    // Get an item from the cache by its key
    Task<T> GetAsync<T>(string key) ;

    // Remove an item from the cache by its key
    Task RemoveAsync(string key);

    // Check if an item exists in the cache by its key
    Task<bool> ExistsAsync(string key);

    // Clear all items from the cache
    Task ClearAsync();
}
