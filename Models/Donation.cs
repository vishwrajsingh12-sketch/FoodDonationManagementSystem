using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDonationManagementSystem.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        public string FoodName { get; set; }

        public string FoodType { get; set; }

        public string FoodImage { get; set; }

        public string Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string PickupAddress { get; set; }

        public string Status { get; set; }
        // Pending / Accepted / Completed

        // store Identity user id (string)
        public string UserId { get; set; }
    }
}
