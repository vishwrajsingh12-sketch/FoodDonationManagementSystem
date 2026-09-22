using FoodDonationManagementSystem.Data;
using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDonationManagementSystem.Controllers
{
    public class ContactController : Controller
    {

        private readonly FoodDonationContext _context;


        public ContactController(FoodDonationContext context)
        {
            _context = context;
        }




        // USER CONTACT PAGE

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }




        // SAVE MESSAGE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {

            if (ModelState.IsValid)
            {

                contact.CreatedAt = DateTime.Now;


                _context.Contacts.Add(contact);


                await _context.SaveChangesAsync();


                TempData["Success"] = "Your message has been sent successfully!";

                return RedirectToAction("Index");

            }


            return View(contact);

        }







        // ADMIN VIEW CONTACT MESSAGES

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Messages()
        {

            var messages = await _context.Contacts
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();


            return View(messages);

        }







        // DELETE MESSAGE (ADMIN)

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var contact = await _context.Contacts
                .FindAsync(id);


            if (contact == null)
            {
                return NotFound();
            }


            _context.Contacts.Remove(contact);


            await _context.SaveChangesAsync();


            return RedirectToAction("Messages");

        }


    }
}