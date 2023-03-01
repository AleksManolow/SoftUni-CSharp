using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.TownNameMaxLength)]
        public string Name { get; set; } = null!;
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        [InverseProperty(nameof(Team.Town))]
        public virtual ICollection<Team> Teams { get; set; } = null!;
    }
}
