using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; } = null!;
        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression(@"^The [A-Z][a-z]+$")]
        public string Nickname { get; set; } = null!;
        [JsonProperty("Age")]
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }
        [JsonProperty("IncarcerationDate")]
        [Required]
        public string IncarcerationDate { get; set; } = null!;
        [JsonProperty("ReleaseDate")]
        public string? ReleaseDate { get; set; }
        [JsonProperty("Bail")]
        public decimal? Bail { get; set; }
        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public ImportMailDto[] Mails { get; set; }
    }
}
