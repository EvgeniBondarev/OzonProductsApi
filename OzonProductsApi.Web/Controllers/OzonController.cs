using Microsoft.AspNetCore.Mvc;
using OzonProductsApi.Application.OzonApiClient.Interfaces;
using OzonProductsApi.Application.OzonApiClient.Models.Request;
using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OzonController : ControllerBase
{
    private readonly IOzonApiClient _ozonApiClient;

    public OzonController(IOzonApiClient ozonApiClient)
    {
        _ozonApiClient = ozonApiClient;
    }

    /// <summary>
    /// Пример вызова API Ozon для получения дерева категорий описаний.
    /// </summary>
    /// <returns>Дерево категорий в виде типизированной модели</returns>
    [HttpPost("description-category-tree")]
    public async Task<IActionResult> GetDescriptionCategoryTree()
    {
        // Пример заголовков
        var headers = new Dictionary<string, string>
        {
            { "Client-Id", "482702" },
            { "Api-Key", "7ae789b7-93ff-4ca7-aae0-4f47f48ffdec" },
        };

        // Модель запроса
        var payload = new DescriptionCategoryPayload
        {
            Language = "RU" // Можно изменить на "EN", "TR", "ZH_HANS"
        };

        // URL конечной точки
        string url = "https://api-seller.ozon.ru/v1/description-category/tree";

        try
        {
            // Отправляем запрос и получаем типизированный ответ
            CategoryTreeResponse response = await _ozonApiClient.SendRequestAsync<DescriptionCategoryPayload, CategoryTreeResponse>(
                HttpMethod.Post,
                url,
                headers,
                payload);

            // В данном примере возвращаем полученный ответ клиенту
            return Ok(response);
        }
        catch (Exception ex)
        {
            // При возникновении ошибки возвращаем 500 с текстом ошибки
            return StatusCode(500, ex.Message);
        }
    }
    
    // <summary>
    /// Получение атрибутов описания категории.
    /// </summary>
    /// <returns>Типизированный ответ с атрибутами</returns>
    [HttpPost("description-category-attribute")]
    public async Task<IActionResult> GetDescriptionCategoryAttribute()
    {
        // Заголовки запроса
        var headers = new Dictionary<string, string>
        {
            { "Client-Id", "482702" },
            { "Api-Key", "7ae789b7-93ff-4ca7-aae0-4f47f48ffdec" }
        };

        // Модель запроса
        var payload = new DescriptionCategoryAttributePayload
        {
            DescriptionCategoryId = 17028760,
            Language = "DEFAULT",
            TypeId = 970621654
        };

        // URL конечной точки
        string url = "https://api-seller.ozon.ru/v1/description-category/attribute";

        try
        {
            // Отправляем запрос и получаем типизированный ответ
            DescriptionCategoryAttributeResponse response =
                await _ozonApiClient.SendRequestAsync<DescriptionCategoryAttributePayload, DescriptionCategoryAttributeResponse>(
                    HttpMethod.Post,
                    url,
                    headers,
                    payload);

            // Возвращаем результат клиенту
            return Ok(response);
        }
        catch (Exception ex)
        {
            // При возникновении ошибки возвращаем статус 500 с сообщением ошибки
            return StatusCode(500, ex.Message);
        }
    }
    
    /// <summary>
    /// Получение значений атрибута описания категории.
    /// </summary>
    /// <returns>Типизированный ответ с массивом значений атрибута и флагом наличия следующих значений</returns>
    [HttpPost("description-category-attribute-values")]
    public async Task<IActionResult> GetDescriptionCategoryAttributeValues()
    {
        // Заголовки запроса
        var headers = new Dictionary<string, string>
        {
            { "Client-Id", "482702" },
            { "Api-Key", "26817ffe-ac88-430d-8b97-720704598fc6" },
        };

        // Модель запроса
        var payload = new DescriptionCategoryAttributeValuesPayload
        {
            AttributeId = 9782,
            DescriptionCategoryId = 17028760,
            Language = "DEFAULT",
            LastValueId = 0,
            Limit = 100,
            TypeId = 970621654
        };

        // URL конечной точки API
        string url = "https://api-seller.ozon.ru/v1/description-category/attribute/values";

        try
        {
            // Отправляем запрос и получаем типизированный ответ
            DescriptionCategoryAttributeValuesResponse response =
                await _ozonApiClient.SendRequestAsync<DescriptionCategoryAttributeValuesPayload, DescriptionCategoryAttributeValuesResponse>(
                    HttpMethod.Post,
                    url,
                    headers,
                    payload);

            // Возвращаем результат клиенту
            return Ok(response);
        }
        catch (Exception ex)
        {
            // При ошибке возвращаем статус 500 с сообщением об ошибке
            return StatusCode(500, ex.Message);
        }
    }
        /// <summary>
        /// Импорт продукта в Ozon.
        /// </summary>
        /// <returns>Ответ API импорта продукта</returns>
        [HttpPost("product/import")]
        public async Task<IActionResult> ImportProduct()
        {
            // Заголовки запроса
            var headers = new Dictionary<string, string>
            {
                { "Client-Id", "482702" },
                { "Api-Key", "26817ffe-ac88-430d-8b97-720704598fc6" },
            };

            // Формирование тела запроса с вложенными моделями
            var payload = new ProductImportRequest
            {
                Items = new List<ProductImportItem>
                {
                    new ProductImportItem
                    {
                        Attributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                ComplexId = 0,
                                Id = 5076,
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        DictionaryValueId = 971082156,
                                        Value = "Стойка для акустической системы"
                                    }
                                }
                            },
                            new ProductAttribute
                            {
                                ComplexId = 0,
                                Id = 9048,
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        Value = "Комплект защитных плёнок для X3 NFC. Темный хлопок"
                                    }
                                }
                            },
                            new ProductAttribute
                            {
                                ComplexId = 0,
                                Id = 8229,
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        DictionaryValueId = 95911,
                                        Value = "Комплект защитных плёнок для X3 NFC. Темный хлопок"
                                    }
                                }
                            },
                            new ProductAttribute
                            {
                                ComplexId = 0,
                                Id = 85,
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        DictionaryValueId = 5060050,
                                        Value = "Samsung"
                                    }
                                }
                            },
                            new ProductAttribute
                            {
                                ComplexId = 0,
                                Id = 10096,
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        DictionaryValueId = 61576,
                                        Value = "серый"
                                    }
                                }
                            }
                        },
                        Barcode = "112772873170",
                        DescriptionCategoryId = 17028922,
                        NewDescriptionCategoryId = 0,
                        ColorImage = "",
                        ComplexAttributes = new List<ComplexAttribute>(),
                        CurrencyCode = "RUB",
                        Depth = 10,
                        DimensionUnit = "mm",
                        Height = 74,
                        Images = new List<string>(),
                        Images360 = new List<string>(),
                        Name = "Комплект защитных плёнок для X3 NFC. Темный хлопок",
                        OfferId = "143210608",
                        OldPrice = "1100",
                        PdfList = new List<string>(),
                        Price = "1000",
                        PrimaryImage = "",
                        Vat = "0.1",
                        Weight = 40,
                        WeightUnit = "g",
                        Width = 162
                    }
                }
            };

            // URL API
            string url = "https://api-seller.ozon.ru/v3/product/import";

            try
            {
                // Отправка запроса через IOzonApiClient
                ImportResponse response = await _ozonApiClient.SendRequestAsync<ProductImportRequest, ImportResponse>(
                    HttpMethod.Post,
                    url,
                    headers,
                    payload);

                // Возвращаем полученный ответ
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Получение информации об импорте товаров
        /// </summary>
        [HttpPost("product/import/info")]
        public async Task<IActionResult> GetProductImportInfo()
        {
            // Заголовки запроса
            var headers = new Dictionary<string, string>
            {
                { "Client-Id", "482702" },
                { "Api-Key", "26817ffe-ac88-430d-8b97-720704598fc6" }
            };

            // URL конечной точки API
            string url = "https://api-seller.ozon.ru/v1/product/import/info";
            
            ProductImportInfoPayload payload = new ProductImportInfoPayload()
            {
                TaskId = 1649650839
            };

            try
            {
                // Отправляем запрос и получаем типизированный ответ
                ProductImportInfoResponse response =
                    await _ozonApiClient.SendRequestAsync<ProductImportInfoPayload, ProductImportInfoResponse>(
                        HttpMethod.Post,
                        url,
                        headers,
                        payload);

                // Возвращаем результат клиенту
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
}   