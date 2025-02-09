using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public class CategoryTreeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(CategoryTreeResponse).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var response = new CategoryTreeResponse();

        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);
            if (obj.TryGetValue("result", out JToken? resultToken) && resultToken.Type == JTokenType.Array)
            {
                response.Categories = ParseCategoryArray((JArray)resultToken);
            }
        }
        else if (reader.TokenType == JsonToken.StartArray)
        {
            response.Categories = ParseCategoryArray(JArray.Load(reader));
        }

        return response;
    }

    private List<CategoryNode> ParseCategoryArray(JArray array)
    {
        var result = new List<CategoryNode>();

        foreach (JToken item in array)
        {
            var node = new CategoryNode
            {
                Id = item["description_category_id"]?.Value<long>() ?? 0,
                Name = item["category_name"]?.Value<string>() ?? string.Empty,
                Disabled = item["disabled"]?.Value<bool>() ?? false,
                TypeName = item["type_name"]?.Value<string>(),
                TypeId = item["type_id"]?.Value<long>(),
                Children = item["children"] is JArray childrenArray 
                    ? ParseCategoryArray(childrenArray) 
                    : new List<CategoryNode>()
            };

            result.Add(node);
        }

        return result;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}