using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string Cvc { get; set; } = null!;
        [Required]
        public CardType Type { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [InverseProperty(nameof(Purchase.Card))]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
