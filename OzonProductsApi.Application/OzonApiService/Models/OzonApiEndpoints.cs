namespace OzonProductsApi.Application.OzonApiService;

public static class OzonApiEndpoints
{
    public const string BaseUrl = "https://api-seller.ozon.ru";
    public const string DescriptionCategoryTree = "/v1/description-category/tree";
    public const string DescriptionCategoryAttribute = "/v1/description-category/attribute";
    public const string DescriptionCategoryAttributeValues = "/v1/description-category/attribute/values";
    public const string ProductImport = "/v3/product/import";
    public const string ProductImportInfo = "/v1/product/import/info";
}