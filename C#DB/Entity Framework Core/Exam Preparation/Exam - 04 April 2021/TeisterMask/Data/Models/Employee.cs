using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeesTasks= new HashSet<EmployeeTask>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression("[A-Za-z0-9]")]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; } = null!;


        [InverseProperty(nameof(EmployeeTask.Employee))]
        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
