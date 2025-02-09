using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Request;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class ProductImportRequestConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(ProductImportRequest).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var jObject = JObject.Load(reader);
        var request = new ProductImportRequest();
        serializer.Populate(jObject.CreateReader(), request);
        return request;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
