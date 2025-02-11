using MediatR;
using OzonProductsApi.Persistence.SQL.MySql;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands.Handler;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateTaskCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken ct)
    {
        var entity = new OzonTaskEntity
        {
            TaskId = request.TaskId,
            MongoId = request.MongoId,
            Name = request.Name,
            CreateTime = DateTime.UtcNow,
            OzonClient = request.OzonClient,
            LastStatus = request.LastStatus,
            CheckTime = DateTime.UtcNow
        };

        _context.OzonTasks.Add(entity);
        await _context.SaveChangesAsync(ct);
        return entity.Id;
    }
}