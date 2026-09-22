using Microsoft.AspNetCore.Mvc;

namespace FoodDonationManagementSystem.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Index() => View();
    }
}
