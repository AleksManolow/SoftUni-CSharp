using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();    
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Game.Genre))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
