using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class DescriptionCategoryResponse
{
    [JsonProperty("result")]
    public List<CategoryNode> Result { get; set; }

    public static DescriptionCategoryResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<DescriptionCategoryResponse>(json, Converter.Settings);
}