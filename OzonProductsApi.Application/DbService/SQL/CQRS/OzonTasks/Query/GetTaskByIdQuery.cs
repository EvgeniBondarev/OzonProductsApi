using MediatR;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query;

public record GetTaskByIdQuery(int Id) : IRequest<OzonTaskEntity>;