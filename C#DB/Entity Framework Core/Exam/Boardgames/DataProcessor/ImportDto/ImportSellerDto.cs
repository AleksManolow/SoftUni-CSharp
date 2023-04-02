using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportSellerDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [JsonProperty("Address")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;
        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; } = null!;
        [JsonProperty("Website")]
        [Required]
        [RegularExpression(@"^www.[A-Za-z\d\-]+.com$")]
        public string Website { get; set; } = null!;
        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }
    }
}
