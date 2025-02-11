using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OzonProductsApi.Application.DbService.NoSql.Mongo;
using Swashbuckle.AspNetCore.Annotations;

namespace OzonProductsApi.Controllers;

[ApiController]
[Route("api/dynamic")]
public class DynamicDataController : BaseApiController
{
    private readonly MongoDbService _mongoService;

    public DynamicDataController(
        ILogger<DynamicDataController> logger,
        MongoDbService mongoService) : base(logger)
    {
        _mongoService = mongoService;
    }

    [HttpPost("{collectionName}")]
    [SwaggerOperation(
        Summary = "Создать новый документ",
        Description = "Создает новый документ в указанной коллекции. Если _id не указан, генерируется автоматически.")]
    public async Task<IActionResult> CreateDocument(
        string collectionName,
        [FromBody] JsonElement json)
    {
        try
        {
            // Используем JsonDocument для валидации и нормализации JSON
            using var jsonDoc = JsonDocument.Parse(json.GetRawText());
            var normalizedJson = jsonDoc.RootElement.GetRawText(); // Получаем нормализованный JSON
        
            var id = await _mongoService.InsertAsync(collectionName, normalizedJson);
            return ApiOk(
                id,
                "Документ успешно создан");
        }
        catch (JsonException ex)
        {
            return ApiBadRequest($"Некорректный JSON: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            return ApiBadRequest($"Ошибка при создании документа: {ex.Message}", ex);
        }
    }

    [HttpGet("{collectionName}/{id}")]
    [SwaggerOperation(
        Summary = "Получить документ по ID",
        Description = "Возвращает документ из указанной коллекции по его идентификатору")]
    public async Task<IActionResult> GetDocument(string collectionName, string id)
    {
        try
        {
            var json = await _mongoService.GetByIdAsync(collectionName, id);
            return json != null 
                ? Content(json, "application/json") 
                : ApiNotFound("Документ не найден");
        }
        catch (Exception ex)
        {
            return ApiBadRequest($"Ошибка при получении документа: {ex.Message}", ex);
        }
    }

    [HttpPut("{collectionName}/{id}")]
    [SwaggerOperation(
        Summary = "Заменить документ",
        Description = "Полностью заменяет содержимое документа в указанной коллекции")]
    public async Task<IActionResult> ReplaceDocument(
        string collectionName, 
        string id, 
        [FromBody] JsonElement json)
    {
        try
        {
            var jsonString = json.GetRawText();
            var success = await _mongoService.ReplaceByIdAsync(collectionName, id, jsonString);
            
            return success 
                ? NoContent() 
                : ApiNotFound("Документ для замены не найден");
        }
        catch (Exception ex)
        {
            return ApiBadRequest($"Ошибка при замене документа: {ex.Message}", ex);
        }
    }
}