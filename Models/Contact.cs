using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models
{
    public class Contact
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;



        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; } = string.Empty;



        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = string.Empty;



        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}