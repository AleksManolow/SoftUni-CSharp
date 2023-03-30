using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
            Mails = new HashSet<Mail>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; } = null!;
        [Required]
        [RegularExpression(@"^The [A-Z][a-z]+$")]
        public string Nickname { get; set; } = null!;
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }
        [Required]
        public DateTime IncarcerationDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int CellId { get; set; }
        public virtual Cell? Cell { get; set; }

        [InverseProperty(nameof(Mail.Prisoner))]
        public virtual ICollection<Mail> Mails { get; set; }


        [InverseProperty(nameof(OfficerPrisoner.Prisoner))]
        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}
