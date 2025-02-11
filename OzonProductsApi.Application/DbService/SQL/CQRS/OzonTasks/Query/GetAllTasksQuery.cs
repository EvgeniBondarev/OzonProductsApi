using MediatR;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query;

public record GetAllTasksQuery : IRequest<List<OzonTaskEntity>>;
