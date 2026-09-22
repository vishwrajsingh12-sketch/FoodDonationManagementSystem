using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        // optional role selection during registration (Admin/Donor/NGO) - usually set by admin
        public string Role { get; set; }
    }
}
