using MediatR;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands;

public record UpdateTaskCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string LastStatus { get; init; }
    public DateTime CheckTime { get; init; }
}