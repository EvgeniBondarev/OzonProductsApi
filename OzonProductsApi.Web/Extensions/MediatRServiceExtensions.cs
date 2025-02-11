using MediatR.NotificationPublishers;
using OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands.Handler;
using OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query.Handler;

namespace OzonProductsApi.Extensions;

public static class MediatRServiceExtensions
{
    public static IServiceCollection AddCqrsHandlers(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(CreateTaskCommandHandler).Assembly,
                typeof(UpdateTaskCommandHandler).Assembly,
                typeof(DeleteTaskCommandHandler).Assembly,
                typeof(GetAllTasksQueryHandler).Assembly,
                typeof(GetTaskByIdQueryHandler).Assembly
            );
            
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);
        });

        return services;
    }
}