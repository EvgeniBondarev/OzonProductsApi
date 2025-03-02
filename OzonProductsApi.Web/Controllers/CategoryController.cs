using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzonProductsApi.Application.CategoryTreeService;
using OzonProductsApi.Application.OzonApiClient.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace OzonProductsApi.Controllers;

[Route("api/[controller]")]
public class CategoryController : BaseApiController
{
    private static readonly Task<CategoryTreeManager> _initializationTask;
    private static CategoryTreeManager _categoryTree;

    public static CategoryTreeManager CategoryTree
    {
        get
        {
            _initializationTask.Wait();
            return _categoryTree;
        }
    }
    static CategoryController()
    {
        _initializationTask = InitializeAsync();
    }
    
    private static async Task<CategoryTreeManager> InitializeAsync()
    {
        List<CategoryNode> categories = await CategoryTreeReader.ReadCategoriesAsync();
        _categoryTree = new CategoryTreeManager(categories);
        return _categoryTree;
    }
    public CategoryController(ILogger<CategoryController> logger) : base(logger) { }

    [HttpGet("find-by-type-id/{typeId}")]
    [SwaggerOperation(Summary = "Найти категорию по типу ID", 
        Description = "Метод для поиска категории по ID типа. Возвращает категорию или сообщение о том, что тип не найден.")]
    public IActionResult FindByTypeId(long typeId)
    {
        var result = CategoryTree.FindByTypeId(typeId);
        return result != null ? ApiOk(result) : ApiNotFound("Тип не найден");
    }

    [HttpGet("find-by-type-name/{typeName}")]
    [SwaggerOperation(Summary = "Найти категорию по имени типа", 
        Description = "Метод для поиска категории по имени типа. Возвращает категорию или сообщение о том, что тип не найден.")]
    public IActionResult FindByTypeName(string typeName)
    {
        var result = CategoryTree.FindByTypeName(typeName);
        return result != null ? ApiOk(result) : ApiNotFound("Тип не найден");
    }
}