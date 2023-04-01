using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportMailDto
    {
        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; } = null!;
        [JsonProperty("Sender")]
        [Required]
        public string Sender { get; set; } = null!;
        [JsonProperty("Address")]
        [Required]
        [RegularExpression(@"^[A-Za-z\s\d]+str.$")]
        public string Address { get; set; } = null!;
    }
}
