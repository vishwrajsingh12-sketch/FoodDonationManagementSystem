using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models
{
    public class Request
    {

        [Key]
        public int RequestId { get; set; }



        [Required]
        public int DonationId { get; set; }



        [Required]
        public string NGOId { get; set; } = string.Empty;



        public DateTime RequestDate { get; set; } = DateTime.Now;



        public string Status { get; set; } = "Pending";



        // Navigation Properties

        public Donation? Donation { get; set; }


        public User? NGO { get; set; }

    }
}