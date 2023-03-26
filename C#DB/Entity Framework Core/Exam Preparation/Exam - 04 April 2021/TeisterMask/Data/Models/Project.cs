using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? DueDate { get; set; }

        [InverseProperty(nameof(Task.Project))]
        public virtual ICollection<Task> Tasks { get; set; } 
    }
}
