using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class DescriptionCategoryAttributeResponse
{
    [JsonProperty("result")]
    public List<CategoryAttribute> Result { get; set; }

    public static DescriptionCategoryAttributeResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<DescriptionCategoryAttributeResponse>(json, Converter.Settings);
}