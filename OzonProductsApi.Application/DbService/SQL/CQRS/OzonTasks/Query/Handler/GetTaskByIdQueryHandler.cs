using MediatR;
using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query.Handler;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, OzonTaskEntity>
{
    private readonly ApplicationDbContext _context;

    public GetTaskByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OzonTaskEntity> Handle(GetTaskByIdQuery request, CancellationToken ct)
    {
        return await _context.OzonTasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, ct);
    }
}