using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

[JsonConverter(typeof(AttributeValueConverter))]
public class AttributeValue
{
    [JsonProperty("id")]
    public long Id { get; set; }
        
    [JsonProperty("value")]
    public string Value { get; set; }
        
    [JsonProperty("info")]
    public string Info { get; set; }
        
    [JsonProperty("picture")]
    public string Picture { get; set; }
}