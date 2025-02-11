namespace OzonProductsApi.Extensions;

public static class MvcExtensions
{
    public static void AddMvcServices(this IServiceCollection services)
    {
        services.AddControllers();
    }
}