using P01_StudentSystem_.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.ResourceNameMaxLength)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "VARCHAR")]
        [MaxLength(ValidationConstants.CourseUrlMaxLength)]
        public string Url { get; set; } = null!;
        //Enumerations are stored as integer (non - nullable)
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set;} = null!;
    }
}
