using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class Category : CategoryNode
{
    [JsonProperty("description_category_id")]
    public long DescriptionCategoryId { get; set; }

    [JsonProperty("category_name")]
    public string CategoryName { get; set; }
}