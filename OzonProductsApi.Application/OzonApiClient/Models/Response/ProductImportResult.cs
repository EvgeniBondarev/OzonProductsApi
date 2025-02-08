using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class ProductImportResult
{
    [JsonProperty("items")]
    public List<ProductResultImportItem> Items { get; set; } = new();

    [JsonProperty("total")]
    public int Total { get; set; }
}
