using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class CategoryType : CategoryNode
{
    [JsonProperty("type_name")]
    public string TypeName { get; set; }

    [JsonProperty("type_id")]
    public long TypeId { get; set; }
}