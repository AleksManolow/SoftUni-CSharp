using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    [JsonObject]
    public class SupplierDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("isImporter")]
        public bool isImporter { get; set; }
    }
}
