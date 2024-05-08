using CloudSalesSystem.Domain.Interfaces.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace CloudSalesSystem.Infrastructure.Caching;

/// <summary>
/// Memory cache implementation
/// All methods are async in case we want to add another implementation of persistant cache like Redis
/// So we first store in memory and then in persistent cache
/// </summary>
public class Cache : ICache
{
    private readonly IMemoryCache _memoryCache;

    public Cache(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task AddAsync<T>(string key, T value, TimeSpan expiration)
    {
        _memoryCache.Set(key, value, expiration);
    }

    public async Task ClearAsync()
    {
        _memoryCache.Dispose();
    }

    public async Task<bool> ExistsAsync(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        if (_memoryCache.TryGetValue(key, out T value))
        {
            return value!;
        }
        else
        {
            return default;
        }
    }

    public async Task RemoveAsync(string key)
    {
        _memoryCache.Remove(key);
    }
}
