using Microsoft.AspNetCore.Mvc;
using OzonProductsApi.Application.OzonApiClient.Models.Request;
using OzonProductsApi.Application.OzonApiService;
using Swashbuckle.AspNetCore.Annotations;

namespace OzonProductsApi.Controllers;

[Route("api/[controller]")]
public class OzonApiController : BaseApiController
{
    private readonly IOzonApiService _ozonApiService;

    public OzonApiController(ILogger<OzonApiController> logger, IOzonApiService ozonApiService) : base(logger)
    {
        _ozonApiService = ozonApiService;
    }

    [HttpPost("description-category")]
    [SwaggerOperation(Summary = "Получить дерево категорий", 
                      Description = "Метод для получения дерева описания категории по переданному запросу.")]
    public async Task<IActionResult> GetDescriptionCategory([FromBody] DescriptionCategoryPayload payload)
    {
        var result = await _ozonApiService.GetDescriptionCategoryTreeAsync(payload);
        return result != null ? ApiOk(result) : ApiNotFound("Категория не найдена");
    }

    [HttpPost("description-category-attributes")]
    [SwaggerOperation(Summary = "Получить атрибуты категории", 
                      Description = "Метод для получения атрибутов категории по переданному запросу.")]
    public async Task<IActionResult> GetDescriptionCategoryAttributes([FromBody] DescriptionCategoryAttributePayload payload)
    {
        var result = await _ozonApiService.GetDescriptionCategoryAttributeAsync(payload);
        return result != null ? ApiOk(result) : ApiNotFound("Атрибуты категории не найдены");
    }

    [HttpPost("description-category-attribute-values")]
    [SwaggerOperation(Summary = "Получить значения атрибутов категории", 
                      Description = "Метод для получения значений атрибутов категории по переданному запросу.")]
    public async Task<IActionResult> GetDescriptionCategoryAttributeValues([FromBody] DescriptionCategoryAttributeValuesPayload payload)
    {
        var result = await _ozonApiService.GetDescriptionCategoryAttributeValuesAsync(payload);
        return result != null ? ApiOk(result) : ApiNotFound("Значения атрибутов категории не найдены");
    }

    [HttpPost("product-import")]
    [SwaggerOperation(Summary = "Импорт продукта", 
                      Description = "Метод для импорта продукта в систему. Возвращает результат в виде Id импорта.")]
    public async Task<IActionResult> ImportProduct([FromBody] ProductImportRequest payload)
    {
        var result = await _ozonApiService.ImportProductAsync(payload);
        return result != null ? ApiOk(result) : ApiBadRequest("Ошибка импорта продукта");
    }
    
    [HttpPost("product/import/info")]
    [SwaggerOperation(Summary = "Получение информации об импорте товаров", 
        Description = "Метод для получения информации о текущем импорте товаров. Возвращает данные об импорте или сообщение об ошибке.")]
    public async Task<IActionResult> GetProductImportInfo([FromBody] ProductImportInfoPayload payload)
    {
        var result = await _ozonApiService.GetProductImportInfoAsync(payload);
        return result != null ? ApiOk(result) : ApiNotFound("Информация об импорте не найдена");
    }
}
