using System.Text.Encodings.Web;
using System.Text.Json;
using OzonProductsApi.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfigureLogging(builder.Configuration);
builder.Services.AddMvcServices();     
builder.Services.AddSessionManagement();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddResilientHttpClient();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddMongoServices(builder.Configuration);
builder.Services.AddMySqlDbContext(builder.Configuration);

builder.Services.AddCqrsHandlers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.AllowTrailingCommas = true;
        options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });

var app = builder.Build();

app.ConfigureMiddleware();
app.Run();