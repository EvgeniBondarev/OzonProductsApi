using MediatR;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands;

public record CreateTaskCommand : IRequest<int>
{
    public long TaskId { get; init; }
    public string MongoId { get; init; }
    public string Name { get; init; }
    public long OzonClient { get; init; }
    public string LastStatus { get; init; }
}