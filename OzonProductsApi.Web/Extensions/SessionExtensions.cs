namespace OzonProductsApi.Extensions;

public static class SessionExtensions
{
    public static void AddSessionManagement(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });
    }
}