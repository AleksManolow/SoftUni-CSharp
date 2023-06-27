using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Web.ViewModels.Agent
{
    using static Common.EntityValidationConstants.Agent;
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
