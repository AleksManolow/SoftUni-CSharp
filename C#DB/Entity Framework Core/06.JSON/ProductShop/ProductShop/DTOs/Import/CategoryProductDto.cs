using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    [JsonObject]
    public class CategoryProductDto
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
