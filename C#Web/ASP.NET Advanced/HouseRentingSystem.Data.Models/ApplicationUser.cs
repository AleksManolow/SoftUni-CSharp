using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<House> RenterHouses { get; set; } = new List<House>();
    }
}
