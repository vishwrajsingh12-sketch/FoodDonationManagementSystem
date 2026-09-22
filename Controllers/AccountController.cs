using FoodDonationManagementSystem.Models;
using FoodDonationManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;



        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }





        // ================= REGISTER =================


        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n",
                    ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));

                return Content(errors);
            }



            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                Role = string.IsNullOrEmpty(model.Role)
                       ? "Donor"
                       : model.Role
            };




            var result = await _userManager
                .CreateAsync(user, model.Password);




            if (result.Succeeded)
            {

                string role = string.IsNullOrEmpty(model.Role)
                              ? "Donor"
                              : model.Role;



                await _userManager
                    .AddToRoleAsync(user, role);



                await _signInManager
                    .SignInAsync(user, false);



                return RedirectToAction(
                    "Dashboard",
                    "Donor");

            }




            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    "",
                    error.Description);
            }




            return View(model);

        }








        // ================= LOGIN =================



        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);




            var result = await _signInManager
                .PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    false);




            if (result.Succeeded)
            {

                var user = await _userManager
                    .FindByEmailAsync(model.Email);



                var roles = await _userManager
                    .GetRolesAsync(user);




                if (roles.Contains("Admin"))
                {
                    return RedirectToAction(
                        "Dashboard",
                        "Admin");
                }


                else if (roles.Contains("NGO"))
                {
                    return RedirectToAction(
                        "Dashboard",
                        "NGO");
                }


                else
                {
                    return RedirectToAction(
                        "Dashboard",
                        "Donor");
                }

            }





            ModelState.AddModelError(
                "",
                "Invalid Email or Password");



            return View(model);

        }








        // ================= FORGOT PASSWORD =================




        public IActionResult ForgotPassword()
        {
            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(
            ForgotPasswordViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);




            var user = await _userManager
                .FindByEmailAsync(model.Email);




            if (user == null)
            {

                ModelState.AddModelError(
                    "",
                    "Email not found");


                return View(model);

            }





            var token = await _userManager
                .GeneratePasswordResetTokenAsync(user);





            var resetModel = new ResetPasswordViewModel
            {

                Email = model.Email,

                Token = token

            };




            return View(
                "ResetPassword",
                resetModel);

        }









        // ================= RESET PASSWORD =================




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);




            var user = await _userManager
                .FindByEmailAsync(model.Email);




            if (user == null)
            {

                ModelState.AddModelError(
                    "",
                    "User not found");


                return View(model);

            }





            var result = await _userManager
                .ResetPasswordAsync(
                    user,
                    model.Token,
                    model.Password);






            if (result.Succeeded)
            {

                return RedirectToAction(
                    "Login");

            }






            foreach (var error in result.Errors)
            {

                ModelState.AddModelError(
                    "",
                    error.Description);

            }





            return View(model);

        }









        // ================= LOGOUT =================



        public async Task<IActionResult> Logout()
        {

            await _signInManager
                .SignOutAsync();



            return RedirectToAction(
                "Login");

        }


    }
}