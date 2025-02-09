using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Implementation.Utils;

public static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        Converters =
        {
            new CategoryAttributeConverter(),
            new AttributeValueConverter(),
            new ProductImportRequestConverter(),
            new ProductImportInfoResponseConverter(),
            new CategoryTreeConverter()
        },
        NullValueHandling = NullValueHandling.Ignore,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };
}