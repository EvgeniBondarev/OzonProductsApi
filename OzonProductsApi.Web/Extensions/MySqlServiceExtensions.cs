using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql;

namespace OzonProductsApi.Extensions;

public static class MySqlServiceExtensions
{
    public static IServiceCollection AddMySqlDbContext(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySQL");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}