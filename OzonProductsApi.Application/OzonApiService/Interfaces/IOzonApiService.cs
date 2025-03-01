using OzonProductsApi.Application.OzonApiClient.Models.Request;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.OzonApiService;

public interface IOzonApiService
{
    Task<CategoryTreeResponse> GetDescriptionCategoryTreeAsync(DescriptionCategoryPayload payload);
    Task<DescriptionCategoryAttributeResponse> GetDescriptionCategoryAttributeAsync(DescriptionCategoryAttributePayload payload);
    Task<DescriptionCategoryAttributeValuesResponse> GetDescriptionCategoryAttributeValuesAsync(DescriptionCategoryAttributeValuesPayload payload);
    Task<ImportResponse> ImportProductAsync(ProductImportRequest payload);
    Task<ImportResponse> ImportProductAsync(string payload);
    Task<ProductImportInfoResponse> GetProductImportInfoAsync(ProductImportInfoPayload payload);
}