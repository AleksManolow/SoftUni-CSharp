using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(ValidationConstants.TeamInitialsMaxLenght)]
        public string Initials { get; set; } = null!;
        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public virtual Color PrimaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set;}
        public virtual Color SecondaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(Town))]  
        public int TownId { get; set; }
        public virtual Town Town { get; set;} = null!;

        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; } = null!;

        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; } = null!;
        [InverseProperty(nameof(Player.Team))]
        public virtual ICollection<Player> Players { get; set; } = null!;
    }
}