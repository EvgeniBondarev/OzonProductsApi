using Polly;

namespace OzonProductsApi.Extensions;

public static class HttpClientExtensions
{
    public static void AddResilientHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("RetryClient")
            .AddTransientHttpErrorPolicy(policy =>
                policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)));
    }
}