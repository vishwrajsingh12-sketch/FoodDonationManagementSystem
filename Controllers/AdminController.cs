using FoodDonationManagementSystem.Data;
using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly FoodDonationContext _context;

        public AdminController(FoodDonationContext context)
        {
            _context = context;
        }

        // ================= DASHBOARD =================


        public async Task<IActionResult> Dashboard()
        {

            ViewBag.TotalUsers =
                await _context.Users.CountAsync();


            ViewBag.TotalDonations =
                await _context.Donations.CountAsync();


            ViewBag.Pending =
                await _context.Donations
                .CountAsync(x => x.Status == "Pending");


            ViewBag.Completed =
                await _context.Donations
                .CountAsync(x => x.Status == "Completed");


            return View();

        }

        // ================= USERS =================

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users
                .OrderBy(x => x.Name)
                .ToListAsync();

            return View(users);
        }

        // ================= DONATIONS =================

        public async Task<IActionResult> Donations()
        {
            var donations = await _context.Donations
                .OrderByDescending(x => x.DonationId)
                .ToListAsync();

            return View(donations);
        }

        // ================= REPORTS =================

        public async Task<IActionResult> Reports()
        {
            ViewBag.TotalUsers = await _context.Users.CountAsync();

            ViewBag.TotalDonations = await _context.Donations.CountAsync();

            ViewBag.PendingDonations = await _context.Donations
                .CountAsync(x => x.Status == "Pending");

            ViewBag.CompletedDonations = await _context.Donations
                .CountAsync(x => x.Status == "Completed");

            int total = ViewBag.TotalDonations;

            if (total == 0)
            {
                total = 1;
            }

            ViewBag.PendingPercent =
                ((int)ViewBag.PendingDonations * 100) / total;

            ViewBag.CompletedPercent =
                ((int)ViewBag.CompletedDonations * 100) / total;

            return View();
        }

        // ================= SETTINGS =================

        public IActionResult Settings()
        {
            return View();
        }

        // ================= DELETE USER =================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Users));
        }

        // ================= DELETE DONATION =================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donation = await _context.Donations.FindAsync(id);

            if (donation == null)
            {
                return NotFound();
            }

            _context.Donations.Remove(donation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Donations));
        }
    }
}