using P02_FootballBetting.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.ColorNameMaxLength)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; } = null!;

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; } = null!;
    }
}
