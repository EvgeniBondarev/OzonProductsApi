using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

[JsonConverter(typeof(CategoryNodeConverter))]
public abstract class CategoryNode
{
    [JsonProperty("disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("children")]
    public List<CategoryNode> Children { get; set; }
}