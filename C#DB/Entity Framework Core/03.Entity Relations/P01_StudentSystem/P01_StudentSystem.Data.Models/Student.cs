using P01_StudentSystem_.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "CHAR")]
        [StringLength(ValidationConstants.StudentPhoneNumberLength)]
        public string? PhoneNumber  { get; set; }
        // In Sql Server - Bool -> BIT
        // Not Required
        public bool RegisteredOn { get; set; }
        //Is Required by default!
        //DateTime? is nullable
        public DateTime? Birthday { get; set; }

        [InverseProperty(nameof(StudentCourse.Student))]
        public ICollection<StudentCourse> StudentCourses { get; set; }

        [InverseProperty(nameof(Homework.Student))]
        public ICollection<Homework> Homeworks { get; set; }
    }
}