using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodDonationManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }




        // HOME PAGE

        public IActionResult Index()
        {
            return View();
        }





        // ABOUT US PAGE

        public IActionResult About()
        {
            return View();
        }





        // PRIVACY PAGE

        public IActionResult Privacy()
        {
            return View();
        }





        // ERROR PAGE

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {

            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
                });

        }


    }
}