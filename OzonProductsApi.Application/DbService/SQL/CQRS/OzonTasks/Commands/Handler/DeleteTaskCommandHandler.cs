using MediatR;
using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands.Handler;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteTaskCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken ct)
    {
        var task = await _context.OzonTasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, ct);

        if (task == null) return false;

        _context.OzonTasks.Remove(task);
        return await _context.SaveChangesAsync(ct) > 0;
    }
}