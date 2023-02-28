using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.TeamLogoUrlMaxLength)]
        public string LogoUrl { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.Initials)]
        public string Initials { get; set; } = null!;
        public decimal Budget { get; set; }
        public int PrimaryKitColorId { get; set; }
        public int SecondaryKitColorId { get; set;}
        public int TownId { get; set; }
    }
}