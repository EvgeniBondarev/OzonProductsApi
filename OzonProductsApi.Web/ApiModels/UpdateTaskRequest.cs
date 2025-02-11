namespace OzonProductsApi.ApiModels;

public record UpdateTaskRequest(
    string LastStatus,
    DateTime CheckTime);