using MongoDB.Driver;
using OzonProductsApi.Application.DbService.NoSql.Mongo;
using OzonProductsApi.Persistence.NoSql.Mongo;

namespace OzonProductsApi.Extensions;

public static class MongoDbServiceExtensions
{
    public static IServiceCollection AddMongoServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoClient>(provider =>
        {
            var connectionString = configuration.GetConnectionString("MongoDB");
            return new MongoClient(connectionString);
        });

        services.AddScoped<MongoDbContext>(provider =>
        {
            var client = provider.GetRequiredService<MongoClient>();
            var databaseName = configuration["MongoDbSettings:DatabaseName"];
            return new MongoDbContext(client, databaseName);
        });

        services.AddScoped<MongoDbService>();

        return services;
    }
}