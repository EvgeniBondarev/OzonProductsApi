using System.Text;
using Microsoft.AspNetCore.Mvc;
using OzonProductsApi.Utils;

namespace OzonProductsApi.Controllers;

public abstract class BaseApiController : ControllerBase
{
    private readonly ILogger<BaseApiController> _logger;

    static BaseApiController()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    protected BaseApiController(ILogger<BaseApiController> logger)
    {
        _logger = logger;
    }

    protected IActionResult ApiOk<T>(T result, string message = "Запрос выполнен успешно")
    {
        var response = ApiResponse<T>.Success(result, message);
        string resultPreview = GetResultPreview(result);
        string controller = ControllerContext.ActionDescriptor.ControllerName;
        string action = ControllerContext.ActionDescriptor.ActionName;

        _logger.LogInformation(
            "✅ 200 OK | {Controller}.{Action} | {Message} | {Time} | Result: {ResultPreview}",
            controller, action, response.Message, response.Time, resultPreview
        );

        return Ok(response);
    }

    protected IActionResult ApiNotFound(string message = "Ресурс не найден")
    {
        var response = ApiResponse<object>.Failure(message);
        string controller = ControllerContext.ActionDescriptor.ControllerName;
        string action = ControllerContext.ActionDescriptor.ActionName;

        _logger.LogWarning(
            "⚠️ 404 Not Found | {Controller}.{Action} | {Message} | {Time}",
            controller, action, response.Message, response.Time
        );

        return NotFound(response);
    }

    protected IActionResult ApiBadRequest(string message, Exception? ex = null)
    {
        var response = ApiResponse<object>.Failure(message);
        string controller = ControllerContext.ActionDescriptor.ControllerName;
        string action = ControllerContext.ActionDescriptor.ActionName;

        if (ex != null)
        {
            _logger.LogError(
                "❌ 400 Bad Request | {Controller}.{Action} | {Message} | {Time} | Ошибка: {Error} | Файл: {File} | Строка: {Line}",
                controller, action, response.Message, response.Time, ex.Message, GetExceptionFile(ex), GetExceptionLine(ex)
            );
        }
        else
        {
            _logger.LogError(
                "❌ 400 Bad Request | {Controller}.{Action} | {Message} | {Time}",
                controller, action, response.Message, response.Time
            );
        }

        return BadRequest(response);
    }

    private static string GetExceptionFile(Exception ex)
    {
        var frame = new System.Diagnostics.StackTrace(ex, true).GetFrame(0);
        return frame?.GetFileName() ?? "Неизвестный файл";
    }

    private static int GetExceptionLine(Exception ex)
    {
        var frame = new System.Diagnostics.StackTrace(ex, true).GetFrame(0);
        return frame?.GetFileLineNumber() ?? 0;
    }

    private static string GetResultPreview<T>(T result)
    {
        if (result == null) return "null";

        return result switch
        {
            string str => str.Length > 100 ? str.Substring(0, 100) + "..." : str,  
            IEnumerable<object> collection => $"[Коллекция {collection.Count()} элементов]",  
            _ => $"[Тип: {result.GetType().Name}]" 
        };
    }

}
