using FoodDonationManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Controllers
{
    [Authorize(Roles = "NGO")]
    public class NGOController : Controller
    {
        private readonly FoodDonationContext _context;


        public NGOController(FoodDonationContext context)
        {
            _context = context;
        }




        // ================= NGO DASHBOARD =================


        public async Task<IActionResult> Dashboard()
        {

            ViewBag.TotalFood = await _context.Donations
                .CountAsync();



            ViewBag.PendingFood = await _context.Donations
                .CountAsync(x => x.Status == "Pending");



            ViewBag.AcceptedFood = await _context.Donations
                .CountAsync(x => x.Status == "Accepted");



            ViewBag.CompletedFood = await _context.Donations
                .CountAsync(x => x.Status == "Completed");



            return View();

        }






        // ================= AVAILABLE DONATIONS =================


        public async Task<IActionResult> AvailableDonations(string search)
        {

            var query = _context.Donations
                .Where(x => x.Status == "Pending"
                         || x.Status == "Accepted")
                .AsQueryable();




            if (!string.IsNullOrEmpty(search))
            {

                query = query.Where(x =>
                    x.FoodName.Contains(search));


                ViewBag.Search = search;

            }




            var donations = await query.ToListAsync();



            return View(donations);

        }







        // ================= ACCEPT DONATION =================


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptDonation(int id)
        {

            var donation = await _context.Donations
                .FindAsync(id);



            if (donation == null)
                return NotFound();




            donation.Status = "Accepted";



            await _context.SaveChangesAsync();



            return RedirectToAction(
                "AvailableDonations");

        }








        // ================= COMPLETE PICKUP =================


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteDonation(int id)
        {

            var donation = await _context.Donations
                .FindAsync(id);



            if (donation == null)
                return NotFound();




            donation.Status = "Completed";



            await _context.SaveChangesAsync();



            return RedirectToAction(
                "AvailableDonations");

        }



    }
}