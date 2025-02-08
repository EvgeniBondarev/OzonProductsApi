using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class DescriptionCategoryAttributeValuesResponse
{
    [JsonProperty("result")]
    public List<AttributeValue> Result { get; set; }
        
    [JsonProperty("has_next")]
    public bool HasNext { get; set; }

    public static DescriptionCategoryAttributeValuesResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<DescriptionCategoryAttributeValuesResponse>(json, Converter.Settings);
}