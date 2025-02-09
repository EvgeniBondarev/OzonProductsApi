using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class CategoryNode
{
    [JsonProperty("description_category_id")]
    public long? Id { get; set; }

    [JsonProperty("category_name")]
    public string? Name { get; set; } = string.Empty;

    [JsonProperty("disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("children")]
    public List<CategoryNode> Children { get; set; } = new();

    // Для конечных листьев дерева
    [JsonProperty("type_name", NullValueHandling = NullValueHandling.Ignore)]
    public string? TypeName { get; set; }

    [JsonProperty("type_id", NullValueHandling = NullValueHandling.Ignore)]
    public long? TypeId { get; set; }
}