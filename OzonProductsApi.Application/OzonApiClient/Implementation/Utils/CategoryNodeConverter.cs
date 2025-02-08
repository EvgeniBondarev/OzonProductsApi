using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils
{
    public class CategoryNodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(CategoryNode).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jObject = JObject.Load(reader);
            CategoryNode target;

            if (jObject["description_category_id"] != null)
            {
                target = new Category();
            }
            else if (jObject["type_name"] != null)
            {
                target = new CategoryType();
            }
            else
            {
                throw new JsonSerializationException("Неизвестный тип узла дерева категорий.");
            }

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}