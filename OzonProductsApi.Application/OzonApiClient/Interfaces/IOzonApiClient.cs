namespace OzonProductsApi.Application.OzonApiClient.Interfaces;

public interface IOzonApiClient
{
    /// <summary>
    /// Отправляет HTTP-запрос с моделью запроса и возвращает модель ответа, десериализованную из JSON.
    /// </summary>
    /// <typeparam name="TRequest">Тип модели запроса</typeparam>
    /// <typeparam name="TResponse">Тип модели ответа</typeparam>
    /// <param name="method">HTTP-метод запроса</param>
    /// <param name="endpoint">URL конечной точки</param>
    /// <param name="headers">Словарь заголовков</param>
    /// <param name="payload">Модель запроса</param>
    /// <returns>Ответ в виде десериализованной модели</returns>
    Task<TResponse> SendRequestAsync<TRequest, TResponse>(
        HttpMethod method,
        string endpoint,
        Dictionary<string, string>? headers,
        TRequest payload);
}