using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.PlayerNameMaxLength)]
        public string Name { get; set; } = null!;
        public int SquadNumber { get; set; }
        public bool IsInjured { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!;
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set;}
        public virtual Position Position { get; set; } = null!;

        [InverseProperty(nameof(PlayerStatistic.Player))]
        public ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
    }
}
