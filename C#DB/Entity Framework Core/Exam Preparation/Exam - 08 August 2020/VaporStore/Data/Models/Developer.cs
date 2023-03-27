using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Game.Developer))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
