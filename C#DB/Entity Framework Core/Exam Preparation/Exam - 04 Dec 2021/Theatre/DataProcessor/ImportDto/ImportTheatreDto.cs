
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTheatreDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [JsonProperty("NumberOfHalls")]
        [Required]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }
        [JsonProperty("Director")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; } = null!;
        [JsonProperty("Tickets")]
        public ImportTicketsDto[] Tickets { get; set; }
    }
}
