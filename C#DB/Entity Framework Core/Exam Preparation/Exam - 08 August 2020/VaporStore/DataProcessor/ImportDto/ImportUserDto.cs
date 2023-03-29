using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUserDto
    {
        [JsonProperty("FullName")]
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; } = null!;
        [JsonProperty("Username")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; } = null!;
        [JsonProperty("Email")]
        [Required]
        public string Email { get; set; } = null!;
        [JsonProperty("Age")]
        [Required]
        [Range(3, 103)]
        public int Age { get; set; }
        [JsonProperty("Cards")]
        public ImportCardDto[] Cards { get; set; }
    }
}
