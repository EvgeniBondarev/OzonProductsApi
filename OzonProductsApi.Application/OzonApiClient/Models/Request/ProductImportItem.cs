using Newtonsoft.Json;

namespace OzonProductsApi.Application.OzonApiClient.Models.Request;

public class ProductImportItem
{
    [JsonProperty("attributes")]
    public List<ProductAttribute> Attributes { get; set; }

    [JsonProperty("barcode")]
    public string Barcode { get; set; }

    [JsonProperty("description_category_id")]
    public long DescriptionCategoryId { get; set; }

    [JsonProperty("new_description_category_id")]
    public long NewDescriptionCategoryId { get; set; }

    [JsonProperty("color_image")]
    public string ColorImage { get; set; }

    [JsonProperty("complex_attributes")]
    public List<ComplexAttribute> ComplexAttributes { get; set; }

    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonProperty("depth")]
    public int Depth { get; set; }

    [JsonProperty("dimension_unit")]
    public string DimensionUnit { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("images")]
    public List<string> Images { get; set; }

    [JsonProperty("images360")]
    public List<string> Images360 { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("offer_id")]
    public string OfferId { get; set; }

    [JsonProperty("old_price")]
    public string OldPrice { get; set; }

    [JsonProperty("pdf_list")]
    public List<string> PdfList { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("primary_image")]
    public string PrimaryImage { get; set; }

    [JsonProperty("vat")]
    public string Vat { get; set; }

    [JsonProperty("weight")]
    public int Weight { get; set; }

    [JsonProperty("weight_unit")]
    public string WeightUnit { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }
}