using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportGameDto
    { 
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; } = null!;
        [JsonProperty("Price")]
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; } = null!;
        [JsonProperty("Developer")]
        [Required]
        public string Developer { get; set; } = null!;
        [JsonProperty("Genre")]
        [Required]
        public string Genre { get; set; } = null!;
        [JsonProperty("Tags")]
        [Required]
        public string[] Tags { get; set; } 
    }
}
