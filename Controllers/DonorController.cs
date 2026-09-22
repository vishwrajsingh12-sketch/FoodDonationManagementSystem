using FoodDonationManagementSystem.Data;
using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Controllers
{
    [Authorize(Roles = "Donor")]
    public class DonorController : Controller
    {
        private readonly FoodDonationContext _context;
        private readonly IWebHostEnvironment _env;

        public DonorController(
            FoodDonationContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ================= DASHBOARD =================

        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.TotalDonation = await _context.Donations
                .CountAsync(x => x.UserId == userId);

            ViewBag.Pending = await _context.Donations
                .CountAsync(x => x.UserId == userId &&
                                 x.Status == "Pending");

            ViewBag.Completed = await _context.Donations
                .CountAsync(x => x.UserId == userId &&
                                 x.Status == "Completed");

            return View();
        }

        // ================= ADD DONATION =================

        public IActionResult AddDonation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDonation(
            Donation donation,
            IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(
                    _env.WebRootPath,
                    "images",
                    "food");

                Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(imageFile.FileName);

                var filePath = Path.Combine(
                    uploads,
                    fileName);

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                donation.FoodImage = "/images/food/" + fileName;
            }
            else
            {
                donation.FoodImage = "/images/food/default.png";
            }

            donation.Status = "Pending";

            donation.UserId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            _context.Donations.Add(donation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyDonations));
        }

        // ================= MY DONATIONS =================

        public async Task<IActionResult> MyDonations()
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            var donations = await _context.Donations
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DonationId)
                .ToListAsync();

            return View(donations);
        }

        // ================= EDIT DONATION =================

        public async Task<IActionResult> EditDonation(int id)
        {
            var donation = await _context.Donations
                .FindAsync(id);

            if (donation == null)
                return NotFound();

            return View(donation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDonation(
            Donation donation,
            IFormFile imageFile)
        {
            var oldDonation = await _context.Donations
                .FindAsync(donation.DonationId);

            if (oldDonation == null)
                return NotFound();

            oldDonation.FoodName = donation.FoodName;
            oldDonation.FoodType = donation.FoodType;
            oldDonation.Quantity = donation.Quantity;
            oldDonation.ExpiryDate = donation.ExpiryDate;
            oldDonation.PickupAddress = donation.PickupAddress;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(
                    _env.WebRootPath,
                    "images",
                    "food");

                Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(imageFile.FileName);

                var filePath = Path.Combine(
                    uploads,
                    fileName);

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                oldDonation.FoodImage =
                    "/images/food/" + fileName;
            }

            _context.Update(oldDonation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyDonations));
        }

        // ================= DELETE DONATION =================

        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donation = await _context.Donations
                .FindAsync(id);

            if (donation != null)
            {
                _context.Donations.Remove(donation);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyDonations));
        }
    }
}