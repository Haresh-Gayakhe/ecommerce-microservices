using ECommerce.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ECommerce.Infrastructure.Services.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var cacheValue = await _cache.GetStringAsync(key);

            if(cacheValue is null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(cacheValue);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration,
            };

            var json = JsonSerializer.Serialize(value);

            await _cache.SetStringAsync(key, json, options);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
