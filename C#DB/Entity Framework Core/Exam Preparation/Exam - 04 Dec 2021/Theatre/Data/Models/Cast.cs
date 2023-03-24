using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; } = null!;
        [Required]
        public bool IsMainCharacter { get; set; }
        [Required]
        [RegularExpression(@"^\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}$")]
        public string PhoneNumber { get; set; } = null!;
        [Required, ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; } = null!;

    }
}
