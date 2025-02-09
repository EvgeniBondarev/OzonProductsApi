using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ProductAttributeValue
{
    [JsonProperty("dictionary_value_id", NullValueHandling = NullValueHandling.Ignore)]
    public long? DictionaryValueId { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}