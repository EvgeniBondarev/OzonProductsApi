using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ProductAttribute
{
    [JsonProperty("complex_id")]
    public int ComplexId { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("values")]
    public List<ProductAttributeValue> Values { get; set; }
}