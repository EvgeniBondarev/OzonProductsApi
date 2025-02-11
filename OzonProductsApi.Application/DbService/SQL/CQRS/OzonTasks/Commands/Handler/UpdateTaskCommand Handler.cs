using MediatR;
using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands.Handler;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateTaskCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken ct)
    {
        var task = await _context.OzonTasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, ct);

        if (task == null) return false;

        task.LastStatus = request.LastStatus;
        task.CheckTime = request.CheckTime;

        _context.OzonTasks.Update(task);
        return await _context.SaveChangesAsync(ct) > 0;
    }
}