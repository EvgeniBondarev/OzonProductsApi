using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class ProductImportError
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("field")]
    public string Field { get; set; } = string.Empty;

    [JsonProperty("attribute_id")]
    public int AttributeId { get; set; }

    [JsonProperty("state")]
    public string State { get; set; } = string.Empty;

    [JsonProperty("level")]
    public string Level { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("optional_description_elements")]
    public Dictionary<string, object> OptionalDescriptionElements { get; set; } = new();

    [JsonProperty("attribute_name")]
    public string AttributeName { get; set; } = string.Empty;

    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;
}