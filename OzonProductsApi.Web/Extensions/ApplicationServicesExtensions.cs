namespace OzonProductsApi.Extensions;

using Application.OzonApiClient.Implementation;
using Application.OzonApiClient.Interfaces;
using Application.OzonApiService;
using Application.OzonApiService.Models;
using SlqStudio.Application.Services.Implementation;
using SlqStudio.Application.Services.Models;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOzonApiClient, OzonApiClient>();
        services.Configure<OzonApiSettings>(configuration.GetSection("OzonApi"));
        services.AddScoped<IOzonApiService, OzonApiService>();
        
        var jwtSettings = new JwtSettings
        {
            Key = configuration["Jwt:SecretKey"],
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"],
            ExpirationMinutes = 30
        };
        
        services.AddScoped<JwtTokenService>();
        services.AddScoped<JwtTokenHandler>();
        services.AddSingleton(jwtSettings);
    }
}