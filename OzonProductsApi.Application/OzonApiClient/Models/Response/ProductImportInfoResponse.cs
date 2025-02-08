using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Response;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class ProductImportInfoResponse
{
    [JsonProperty("result")]
    public required ProductImportResult Result { get; set; }

    public static ProductImportInfoResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<ProductImportInfoResponse>(json, Converter.Settings);
}