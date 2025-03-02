using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.CategoryTreeService;

public class CategoryTreeReader
{
     private static readonly HttpClient httpClient = new HttpClient();

    public static async Task<List<CategoryNode>> ReadCategoriesAsync()
    {
        string url = "https://raw.githubusercontent.com/EvgeniBondarev/21Game/refs/heads/master/ozonCategoryTree.json";
        
        try
        {
            string json = await httpClient.GetStringAsync(url);
            var root = JsonConvert.DeserializeObject<Dictionary<string, List<CategoryNode>>>(json);
            return root?["result"] ?? new List<CategoryNode>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return new List<CategoryNode>();
        }
    }
}