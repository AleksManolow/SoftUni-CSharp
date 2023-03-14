
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    [JsonObject]
    public class CategoryDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
