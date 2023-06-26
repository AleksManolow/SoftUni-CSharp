using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.EntityValidationConstants.Agent;
namespace HouseRentingSystem.Data.Models
{
    public class Agent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<House> OwnedHouses { get; set;} = new List<House>();
    }
}
