using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FullName { get; set; } = null!;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public Weapon Weapon { get; set; }
        [Required, ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        [Required]
        public virtual Department Department { get; set; } = null!;

        [InverseProperty(nameof(OfficerPrisoner.Officer))]
        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
