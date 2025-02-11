using MediatR;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands;

public record DeleteTaskCommand(int Id) : IRequest<bool>;