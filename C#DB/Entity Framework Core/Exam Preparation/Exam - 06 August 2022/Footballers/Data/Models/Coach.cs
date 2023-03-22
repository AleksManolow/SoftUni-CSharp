using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            Footballers = new HashSet<Footballer>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [Required]
        public string Nationality { get; set; } = null!;

        [InverseProperty(nameof(Footballer.Coach))]
        public virtual ICollection<Footballer> Footballers { get; set; } = null!;
    }
}
