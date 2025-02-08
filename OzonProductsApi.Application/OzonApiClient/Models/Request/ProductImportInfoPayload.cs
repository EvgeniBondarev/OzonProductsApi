using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ProductImportInfoPayload
{
    [JsonProperty("task_id")]
    public required long TaskId { get; set; }
}