using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;

public class ImportResponse
{
    [JsonProperty("result")]
    public ImportResult Result { get; set; }
}