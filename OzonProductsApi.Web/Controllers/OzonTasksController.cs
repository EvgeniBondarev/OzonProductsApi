using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonProductsApi.ApiModels;
using OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Commands;
using OzonProductsApi.Application.DbService.SQL.CQRS.OzonTasks.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace OzonProductsApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class OzonTasksController : BaseApiController
{
    private readonly IMediator _mediator;

    public OzonTasksController(
        ILogger<OzonTasksController> logger,
        IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Создать новую задачу")]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return ApiOk(id, "Задача успешно создана");
        }
        catch (Exception ex)
        {
            return ApiBadRequest("Ошибка создания задачи", ex);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Получить задачу по ID")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));
            return result != null 
                ? ApiOk(result) 
                : ApiNotFound("Задача не найдена");
        }
        catch (Exception ex)
        {
            return ApiBadRequest("Ошибка получения задачи", ex);
        }
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Обновить статус задачи")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskRequest request)
    {
        try
        {
            var command = new UpdateTaskCommand
            {
                Id = id,
                LastStatus = request.LastStatus,
                CheckTime = request.CheckTime
            };

            var success = await _mediator.Send(command);
            return success ? ApiOk(true, "Задача обновлена") : ApiNotFound();
        }
        catch (Exception ex)
        {
            return ApiBadRequest("Ошибка обновления задачи", ex);
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Удалить задачу")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var success = await _mediator.Send(new DeleteTaskCommand(id));
            return success ? ApiOk(true, "Задача удалена") : ApiNotFound();
        }
        catch (Exception ex)
        {
            return ApiBadRequest("Ошибка удаления задачи", ex);
        }
    }
}