using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ComplexAttribute
{
    [JsonProperty("attributes")]
    public List<ComplexAttributeItem> Attributes { get; set; }
}