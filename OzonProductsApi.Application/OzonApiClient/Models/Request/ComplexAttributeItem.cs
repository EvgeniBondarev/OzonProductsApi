using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ComplexAttributeItem
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("complex_id")]
    public int ComplexId { get; set; }

    [JsonProperty("values")]
    public List<ProductAttributeValue> Values { get; set; }
}