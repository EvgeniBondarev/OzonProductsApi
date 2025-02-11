namespace OzonProductsApi.Persistence.SQL.MySql.Models;

public class OzonTaskEntity
{
    public int Id { get; set; }
    public long TaskId { get; set; }
    public string MongoId { get; set; }
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public long OzonClient { get; set; }
    public string LastStatus { get; set; }
    public DateTime CheckTime { get; set; }
}