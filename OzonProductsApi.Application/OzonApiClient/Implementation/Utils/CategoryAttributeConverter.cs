using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class CategoryAttributeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(CategoryAttribute).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        // Загружаем JSON-объект
        var jObject = JObject.Load(reader);
        // Если требуется, можно добавить проверки (например, наличие обязательных полей),
        // но в данном случае достаточно стандартной десериализации.
        var target = new CategoryAttribute();
        serializer.Populate(jObject.CreateReader(), target);
        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
