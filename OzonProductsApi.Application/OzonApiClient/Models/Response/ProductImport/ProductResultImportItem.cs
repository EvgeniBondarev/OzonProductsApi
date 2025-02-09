using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class ProductResultImportItem
{
    [JsonProperty("offer_id")]
    public required string OfferId { get; set; }

    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    [JsonProperty("status")]
    public required string Status { get; set; }

    [JsonProperty("errors")]
    public List<ProductImportError> Errors { get; set; } = new();
}