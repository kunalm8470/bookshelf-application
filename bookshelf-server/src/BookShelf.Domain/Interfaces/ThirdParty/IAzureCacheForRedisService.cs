namespace BookShelf.Domain.Interfaces.ThirdParty;

public interface IAzureCacheForRedisService
{
    public Task SetAsync<T>(string key, T value, TimeSpan expiry = default) where T : class, new();

    public Task<T> GetAsync<T>(string key) where T : class, new();

    public Task SetStringAsync(string key, string value, TimeSpan expiry = default);

    public Task<string> GetStringAsync(string key);
}
