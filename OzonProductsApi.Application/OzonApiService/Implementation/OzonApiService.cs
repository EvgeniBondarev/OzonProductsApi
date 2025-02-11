using Microsoft.Extensions.Options;
using OzonProductsApi.Application.OzonApiClient.Interfaces;
using OzonProductsApi.Application.OzonApiClient.Models.Request;
using OzonProductsApi.Application.OzonApiClient.Models.Response;
using OzonProductsApi.Application.OzonApiService.Models;

namespace OzonProductsApi.Application.OzonApiService;

public class OzonApiService : IOzonApiService
{
    private readonly IOzonApiClient _ozonApiClient;
    private readonly Dictionary<string, string> _headers;

    public OzonApiService(IOzonApiClient ozonApiClient, IOptions<OzonApiSettings> ozonApiSettings)
    {
        _ozonApiClient = ozonApiClient;
        _headers = new Dictionary<string, string>
        {
            { "Client-Id", ozonApiSettings.Value.ClientId },
            { "Api-Key", ozonApiSettings.Value.ApiKey }
        };
    }
    public async Task<CategoryTreeResponse> GetDescriptionCategoryTreeAsync(DescriptionCategoryPayload payload)
    {
        return await SendRequestAsync<DescriptionCategoryPayload, CategoryTreeResponse>(
            HttpMethod.Post, OzonApiEndpoints.DescriptionCategoryTree, payload);
    }

    public async Task<DescriptionCategoryAttributeResponse> GetDescriptionCategoryAttributeAsync(DescriptionCategoryAttributePayload payload)
    {
        return await SendRequestAsync<DescriptionCategoryAttributePayload, DescriptionCategoryAttributeResponse>(
            HttpMethod.Post, OzonApiEndpoints.DescriptionCategoryAttribute, payload);
    }

    public async Task<DescriptionCategoryAttributeValuesResponse> GetDescriptionCategoryAttributeValuesAsync(DescriptionCategoryAttributeValuesPayload payload)
    {
        return await SendRequestAsync<DescriptionCategoryAttributeValuesPayload, DescriptionCategoryAttributeValuesResponse>(
            HttpMethod.Post, OzonApiEndpoints.DescriptionCategoryAttributeValues, payload);
    }

    public async Task<ImportResponse> ImportProductAsync(ProductImportRequest payload)
    {
        return await SendRequestAsync<ProductImportRequest, ImportResponse>(
            HttpMethod.Post, OzonApiEndpoints.ProductImport, payload);
    }
    
    public async Task<ProductImportInfoResponse> GetProductImportInfoAsync(ProductImportInfoPayload payload)
    {
        return await SendRequestAsync<ProductImportInfoPayload, ProductImportInfoResponse>(
            HttpMethod.Post, OzonApiEndpoints.ProductImportInfo, payload);
    }
    
    private async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod method, string endpoint, TRequest payload)
    {
        try
        {
            string url = $"{OzonApiEndpoints.BaseUrl}{endpoint}";
            return await _ozonApiClient.SendRequestAsync<TRequest, TResponse>(method, url, _headers, payload);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Ошибка при вызове {endpoint}: {ex.Message}", ex);
        }
    }
}