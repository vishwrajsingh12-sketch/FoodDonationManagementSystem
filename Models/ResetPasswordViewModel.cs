using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models.ViewModels
{
    public class ResetPasswordViewModel
    {

        public string Email { get; set; }


        public string Token { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }




        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}