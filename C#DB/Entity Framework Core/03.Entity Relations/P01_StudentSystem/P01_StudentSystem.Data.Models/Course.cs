using P01_StudentSystem_.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course() 
        { 
            this.StudentCourses = new HashSet<StudentCourse>();
            this.Homeworks= new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
        }
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.CoueseNameMaxLength)]
        public string Name { get; set; } = null!;
        public string? Description  { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        [InverseProperty(nameof(StudentCourse.Course))]
        public ICollection<StudentCourse> StudentCourses { get; set; }
        [InverseProperty(nameof(Homework.Course))]
        public ICollection<Homework> Homeworks { get; set; }
        [InverseProperty((nameof(Resource.Course)))]
        public ICollection<Resource> Resources { get; set; }
    }
}
