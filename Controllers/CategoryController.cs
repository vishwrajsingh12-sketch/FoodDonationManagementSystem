using FoodDonationManagementSystem.Data;
using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDonationManagementSystem.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private readonly FoodDonationContext _context;


        public CategoryController(FoodDonationContext context)
        {
            _context = context;
        }





        // ================= LIST CATEGORY =================

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .ToListAsync();

            return View(categories);
        }







        // ================= CREATE GET =================

        public IActionResult Create()
        {
            return View();
        }







        // ================= CREATE POST =================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {

                _context.Categories.Add(category);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }


            return View(category);

        }








        // ================= EDIT GET =================

        public async Task<IActionResult> Edit(int id)
        {

            var category = await _context.Categories
                .FindAsync(id);


            if (category == null)
            {
                return NotFound();
            }


            return View(category);

        }








        // ================= EDIT POST =================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {

            if (id != category.Id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {

                _context.Update(category);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }



            return View(category);

        }








        // ================= DELETE =================

        public async Task<IActionResult> Delete(int id)
        {

            var category = await _context.Categories
                .FindAsync(id);



            if (category == null)
            {
                return NotFound();
            }



            return View(category);

        }








        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            var category = await _context.Categories
                .FindAsync(id);



            if (category != null)
            {

                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();

            }



            return RedirectToAction(nameof(Index));

        }


    }

}