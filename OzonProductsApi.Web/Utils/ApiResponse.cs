namespace OzonProductsApi.Utils;

public class ApiResponse<T>
{
    public string Message { get; set; }
    public bool Error { get; set; }
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public T Result { get; set; }

    public ApiResponse(T result, string message = "Запрос выполнен успешно", bool error = false)
    {
        Result = result;
        Message = message;
        Error = error;
    }

    public static ApiResponse<T> Success(T result, string message = "Запрос выполнен успешно") =>
        new(result, message, false);

    public static ApiResponse<T> Failure(string message) =>
        new(default, message, true);
}