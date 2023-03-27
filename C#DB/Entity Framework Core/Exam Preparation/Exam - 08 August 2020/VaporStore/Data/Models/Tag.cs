using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            GameTags = new HashSet<GameTag>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(GameTag.Tag))]
        public virtual ICollection<GameTag> GameTags { get; set; }
    }
}
