using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent) 
            { 
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent)
            {
                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = 
                await this.agentService.AgentExistsByPhoneNumberAsync(model.PhoneNumber);

            if (!isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Agent with the provided phone number already exists");
            }

            if (this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasActiveRents = await this.agentService
                .HasRentsByUserIdAsync(userId);

            if (userHasActiveRents)
            {
                return this.RedirectToAction("Mine", "House");
            }

            try
            {
                await this.agentService.Create(userId, model);
            }
            catch (Exception)
            {

                return this.RedirectToAction("Index", "Home");
            }
            return this.RedirectToAction("All", "House");
        }
    }
}
