using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCardDto
    {
        [JsonProperty("Number")]
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; } = null!;
        [JsonProperty("Cvc")]
        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string Cvc { get; set; } = null!;
        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; } = null!;
    }
}
