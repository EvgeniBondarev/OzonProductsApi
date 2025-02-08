using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class CategoryAttribute
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("attribute_complex_id")]
    public long AttributeComplexId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("type")]
    public string AttributeType { get; set; }

    [JsonProperty("is_collection")]
    public bool IsCollection { get; set; }

    [JsonProperty("is_required")]
    public bool IsRequired { get; set; }

    [JsonProperty("is_aspect")]
    public bool IsAspect { get; set; }

    [JsonProperty("max_value_count")]
    public int MaxValueCount { get; set; }

    [JsonProperty("group_name")]
    public string GroupName { get; set; }

    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    [JsonProperty("dictionary_id")]
    public long DictionaryId { get; set; }

    [JsonProperty("category_dependent")]
    public bool CategoryDependent { get; set; }
}