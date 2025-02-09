using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class ImportResult
{
    [JsonProperty("task_id")]
    public string TaskId { get; set; }
}