using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            Purchases = new HashSet<Purchase>();
            GameTags = new HashSet<GameTag>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required, ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; } = null!;

        [Required, ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;


        [InverseProperty(nameof(Purchase.Game))]
        public virtual ICollection<Purchase> Purchases { get; set; }

        [InverseProperty(nameof(GameTag.Game))]
        public virtual ICollection<GameTag> GameTags { get; set; }
    }
}
