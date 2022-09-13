using BookShelf.Domain.Interfaces.ThirdParty;
using StackExchange.Redis;
using System.Text.Json;

namespace BookShelf.Infrastructure.ThirdParty;

public class AzureCacheForRedisService : IAzureCacheForRedisService
{
    private readonly IDatabase _db;

    public AzureCacheForRedisService(IDatabase db)
    {
        _db = db;
    }

    public async Task<T> GetAsync<T>(string key) where T : class, new()
    {
        RedisValue fetched = await _db.StringGetAsync(key);

        if (fetched.IsNull)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>((string)fetched);
    }

    public async Task<string> GetStringAsync(string key)
    {
        RedisValue fetched = await _db.StringGetAsync(key);

        if (fetched.IsNull)
        {
            return default;
        }

        return (string)fetched;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiry = default) where T : class, new()
    {
        string serialized = JsonSerializer.Serialize<T>(value);

        await _db.StringSetAsync(key, serialized, expiry);
    }

    public async Task SetStringAsync(string key, string value, TimeSpan expiry = default)
    {
        await _db.StringSetAsync(key, value, expiry);
    }
}
