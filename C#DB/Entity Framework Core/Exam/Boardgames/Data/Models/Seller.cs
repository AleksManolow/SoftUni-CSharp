using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        [Required]
        [RegularExpression(@"^www.[A-Za-z\d\-]+.com$")]
        public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
