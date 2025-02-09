using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ProductImportRequest
{
    [JsonProperty("items")]
    public List<ProductImportItem> Items { get; set; }
}