using Scalar.AspNetCore;

namespace OzonProductsApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
            await next();
            logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
        });

        app.UseSwagger(opt => opt.RouteTemplate = "openapi/{documentName}.json");
        
        app.UseSwaggerUI(opt =>
        {
            opt.RoutePrefix = "swagger";
            opt.SwaggerEndpoint("/openapi/v1.json", "API V1");
        });

        app.MapScalarApiReference("/scalar", opt =>
        {
            opt.Title = "Scalar Example";
            opt.Theme = ScalarTheme.Mars;
            opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}