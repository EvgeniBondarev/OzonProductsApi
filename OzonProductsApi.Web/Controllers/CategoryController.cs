using Microsoft.AspNetCore.Mvc;
using OzonProductsApi.Application.CategoryTreeService;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private static readonly CategoryTreeManager _categoryTree;

    static CategoryController()
    {
        List<CategoryNode> categories = CategoryTreeReader.ReadCategories("D:\\OzonCard\\ozon_category_tree.json");
        _categoryTree = new CategoryTreeManager(categories);
    }

    [HttpGet("find-by-type-id/{typeId}")]
    public IActionResult FindByTypeId(long typeId)
    {
        var result = _categoryTree.FindByTypeId(typeId);
        if (result == null)
            return NotFound("Тип не найден");

        return Ok(result);
    }

    [HttpGet("find-by-type-name/{typeName}")]
    public IActionResult FindByTypeName(string typeName)
    {
        var result = _categoryTree.FindByTypeName(typeName);
        if (result == null)
            return NotFound("Тип не найден");

        return Ok(result);
    }
}