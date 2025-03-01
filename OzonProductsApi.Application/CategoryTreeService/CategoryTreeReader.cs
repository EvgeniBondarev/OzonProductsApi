using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.CategoryTreeService;

public class CategoryTreeReader
{
    public static List<CategoryNode> ReadCategories()
    {
        string rootPath = "D:\\OzonProductsApi-master\\OzonProductsApi.Web\\bin";
        string json = File.ReadAllText(Path.Combine(rootPath, "Data", "ozonCategoryTree.json"));
        var root = JsonConvert.DeserializeObject<Dictionary<string, List<CategoryNode>>>(json);
        return root?["result"] ?? new List<CategoryNode>();
    }
}