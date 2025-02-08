using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class ProductImportInfoResponseConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(ProductImportInfoResponse).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        JObject jObject = JObject.Load(reader);
            
        var response = new ProductImportInfoResponse
        {
            Result = new ProductImportResult()
        };

        if (jObject["result"] is JObject resultObj)
        {
            response.Result.Total = resultObj["total"]?.Value<int>() ?? 0;
                
            if (resultObj["items"] is JArray itemsArray)
            {
                foreach (JToken itemToken in itemsArray)
                {
                    var item = new ProductResultImportItem
                    {
                        OfferId = itemToken["offer_id"]?.Value<string>(),
                        ProductId = itemToken["product_id"]?.Value<long>() ?? 0,
                        Status = itemToken["status"]?.Value<string>(),
                        Errors = itemToken["errors"]?.ToObject<List<ProductImportError>>() ?? new List<ProductImportError>()
                    };
                    response.Result.Items.Add(item);
                }
            }
        }

        return response;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}