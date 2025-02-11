using System.Text.RegularExpressions;
using MongoDB.Bson;

namespace OzonProductsApi.Persistence.NoSql.Mongo;

public class CustomBsonConverter
{
    public static string Convert(BsonDocument document)
    {
        var json = document.ToJson();
        return Regex.Replace(json, @"{\s*""\$oid""\s*:\s*""(\w+)""\s*}", @"""$1""");
    }
}