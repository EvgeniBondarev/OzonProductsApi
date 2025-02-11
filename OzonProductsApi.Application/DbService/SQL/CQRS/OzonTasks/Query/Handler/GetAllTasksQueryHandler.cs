using MediatR;
using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query.Handler;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<OzonTaskEntity>>
{
    private readonly ApplicationDbContext _context;

    public GetAllTasksQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<OzonTaskEntity>> Handle(GetAllTasksQuery request, CancellationToken ct)
    {
        return await _context.OzonTasks.AsNoTracking().ToListAsync(ct);
    }
}