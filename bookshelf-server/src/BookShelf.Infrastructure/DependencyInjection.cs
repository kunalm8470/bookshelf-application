using Azure.Storage.Blobs;
using Azure.Storage;
using BookShelf.Domain.Interfaces.ThirdParty;
using BookShelf.Infrastructure.Data;
using BookShelf.Infrastructure.Data.Interceptors;
using BookShelf.Infrastructure.ThirdParty;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using BookShelf.Domain.Interfaces.CrossCutting;
using BookShelf.Infrastructure.CrossCutting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BookShelf.Infrastructure.Data.Repositories;
using BookShelf.Domain.Interfaces.Repositories;

namespace BookShelf.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register HttpContextAccessor
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Register URI service
        services.AddScoped<IUriService>((serviceProvider) =>
        {
            IHttpContextAccessor accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

            HttpRequest request = accessor.HttpContext.Request;

            string baseUri = $"{request.Scheme}://{request.Host.ToUriComponent()}";

            string requestPath = request.Path.Value;

            return new UriService(baseUri, requestPath);
        });

        // Register EF Core interceptor as scoped lifetime
        services.AddScoped<TimestampInterceptor>();

        // Register EF Core DB context
        services.AddDbContext<BookshelfDbContext>((options) =>
        {
            string connectionString = configuration.GetConnectionString("SqlServer");

            options.UseSqlServer(connectionString);
        });

        // Register EF Core Repositories
        services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
        services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
        services.AddScoped(typeof(IBookReviewRepository), typeof(BookReviewRepository));
        services.AddScoped(typeof(IBookShelfRepository), typeof(BookShelfRepository));
        services.AddScoped(typeof(IUserProfileRepository), typeof(UserProfileRepository));

        // Register DB Context Initializer
        services.AddScoped<BookshelfDbContextInitializer>();
      
        // Register Azure Cache for Redis Repository
        services.AddSingleton<IAzureCacheForRedisService, AzureCacheForRedisService>((serviceProvider) =>
        {
            string redisConnectionString = configuration.GetConnectionString("Redis");

            // For full options see https://stackexchange.github.io/StackExchange.Redis/Configuration.html
            ConfigurationOptions options = ConfigurationOptions.Parse(redisConnectionString);

            options.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;

            options.ConnectRetry = Convert.ToInt32(configuration["Redis:maxRetry"]);

            // See https://stackexchange.github.io/StackExchange.Redis/Configuration.html#reconnectretrypolicy
            options.ReconnectRetryPolicy = new LinearRetry(Convert.ToInt32(configuration["Redis:retryReconnectMilliSecs"]));

            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);

            IDatabase redisDatabase = connectionMultiplexer.GetDatabase();

            return new AzureCacheForRedisService(redisDatabase);
        });

        // Register Azure Blob Storage - Container service
        services.AddSingleton<IAzureBlobStorageService, ProfileBlobStorageService>((serviceProvider) =>
        {
            string accountName = configuration["AzureBlobStorage:accountName"];

            string accountKey = configuration["AzureBlobStorage:accountKey"];

            Uri serviceUri = new($"https://{accountName}.blob.core.windows.net");

            StorageSharedKeyCredential storageSharedKeyCredential = new(accountName, accountKey);

            BlobServiceClient client = new(serviceUri, storageSharedKeyCredential);

            string containerName = configuration["AzureBlobStorage:Profile:containerName"];

            return new ProfileBlobStorageService(client, containerName);
        });

        // Register typed HTTP client for Auth0 API
        
        services.AddHttpClient<Auth0Service>((httpClient) =>
        {
            httpClient.BaseAddress = new Uri(configuration["Auth0:API:Domain"]);

            httpClient.DefaultRequestHeaders.Clear();
        });

        // Register typed HTTP client for Auth0 Management API
        services.AddHttpClient<Auth0ManagementAPIService>((httpClient) =>
        {
            httpClient.BaseAddress = new Uri(configuration["Auth0:API:Domain"]);

            httpClient.DefaultRequestHeaders.Clear();
        });

        return services;
    }
}
