using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class CategoryTreeResponse
{
    [JsonProperty("result")]
    public List<CategoryNode> Categories { get; set; } = new();
}