using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class DescriptionCategoryPayload
{
    [JsonProperty("language")]
    public required string Language { get; set; }
}