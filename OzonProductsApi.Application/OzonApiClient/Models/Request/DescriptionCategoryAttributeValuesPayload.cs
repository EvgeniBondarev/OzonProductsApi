using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class DescriptionCategoryAttributeValuesPayload
{
    [JsonProperty("attribute_id")]
    public long AttributeId { get; set; }
        
    [JsonProperty("description_category_id")]
    public long DescriptionCategoryId { get; set; }
        
    [JsonProperty("language")]
    public string Language { get; set; }
        
    [JsonProperty("last_value_id")]
    public long LastValueId { get; set; }
        
    [JsonProperty("limit")]
    public int Limit { get; set; }
        
    [JsonProperty("type_id")]
    public long TypeId { get; set; }
}