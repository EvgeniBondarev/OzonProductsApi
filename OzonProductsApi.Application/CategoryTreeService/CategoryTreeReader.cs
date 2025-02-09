using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.CategoryTreeService;

public class CategoryTreeReader
{
    public static List<CategoryNode> ReadCategories(string filePath)
    {
        string rootPath = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.FullName ?? Directory.GetCurrentDirectory();
        string json = File.ReadAllText(Path.Combine(rootPath, "Data", "ozonCategoryTree.json"));
        var root = JsonConvert.DeserializeObject<Dictionary<string, List<CategoryNode>>>(json);
        return root?["result"] ?? new List<CategoryNode>();
    }
}