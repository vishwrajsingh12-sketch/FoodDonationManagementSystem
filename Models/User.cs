using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}