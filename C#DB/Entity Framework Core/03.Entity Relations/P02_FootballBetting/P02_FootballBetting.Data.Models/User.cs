using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.UserUsernameMaxLength)]
        public string Username { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.UserPasswordMaxLength)]
        public string Password { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.UserEmailMaxLength)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }

        [InverseProperty(nameof(Bet.User))]
        public virtual ICollection<Bet> Bets { get; set; } = null!;

    }
}
