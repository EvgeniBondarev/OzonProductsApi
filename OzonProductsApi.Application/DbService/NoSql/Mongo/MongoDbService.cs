using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using OzonProductsApi.Persistence.NoSql.Mongo;

namespace OzonProductsApi.Application.DbService.NoSql.Mongo;

public class MongoDbService
{
    private readonly MongoDbContext _context;

    public MongoDbService(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<string> InsertAsync(string collectionName, string jsonDocument)
    {
        try
        {
            using (JsonDocument.Parse(jsonDocument))
            {
                var document = BsonDocument.Parse(jsonDocument);
                var collection = _context.GetCollection(collectionName);
            
                if (!document.Contains("_id"))
                {
                    document["_id"] = ObjectId.GenerateNewId();
                }

                await collection.InsertOneAsync(document);
                return document["_id"].ToString();
            }
        }
        catch (JsonException ex)
        {
            throw new ArgumentException("Invalid JSON format", ex);
        }
    }

    public async Task<string?> GetByIdAsync(string collectionName, string id)
    {
        var collection = _context.GetCollection(collectionName);
        var objectId = ObjectId.Parse(id);
        var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
        var document = await collection.Find(filter).FirstOrDefaultAsync();
        return CustomBsonConverter.Convert(document);
    }

    public async Task<bool> ReplaceByIdAsync(string collectionName, string id, string jsonDocument)
    {
        try
        {
            using (JsonDocument.Parse(jsonDocument))
            {
                var collection = _context.GetCollection(collectionName);
                var objectId = ObjectId.Parse(id);
                var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

                var document = BsonDocument.Parse(jsonDocument);
                document["_id"] = objectId;
                document["_v"] = document.Contains("_v") 
                    ? document["_v"].AsInt32 + 1 
                    : 1;

                var result = await collection.ReplaceOneAsync(filter, document);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
        }
        catch (JsonException ex)
        {
            throw new ArgumentException("Invalid JSON format", ex);
        }
        catch (FormatException ex)
        {
            throw new ArgumentException("Invalid ObjectId format", ex);
        }
    }

    public async Task DeleteByIdAsync(string collectionName, string id)
    {
        var collection = _context.GetCollection(collectionName);
        var objectId = ObjectId.Parse(id);
        var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
        await collection.DeleteOneAsync(filter);
    }
}