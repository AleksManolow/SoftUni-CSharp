using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.CoutryNameMaxLength)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Town.Country))]
        public virtual ICollection<Town> Towns { get; set; } = null!;
    }
}
