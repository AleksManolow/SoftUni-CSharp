using P01_StudentSystem.Data.Models.Enums;
using P01_StudentSystem_.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.HomeworkContentMaxLength)]
        public string Content { get; set; } = null!;
        //Enumerations are stored as integer (non - nullable)
        public ContentType ContentType { get; set; }
        [Required]
        public DateTime SubmissionTime { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set;} = null!;
    }
}
