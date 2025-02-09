using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class AttributeValueConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(AttributeValue).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;
        
        var jObject = JObject.Load(reader);

        var attributeValue = new AttributeValue();
        serializer.Populate(jObject.CreateReader(), attributeValue);
        return attributeValue;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}