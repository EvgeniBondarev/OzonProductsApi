using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class DescriptionCategoryAttributePayload
{
    [JsonProperty("description_category_id")]
    public long DescriptionCategoryId { get; set; }
        
    [JsonProperty("language")]
    public string Language { get; set; } = "DEFAULT";
        
    [JsonProperty("type_id")]
    public long TypeId { get; set; }
}