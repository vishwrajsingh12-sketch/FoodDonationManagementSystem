using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDonationManagementSystem.Data
{
    public class FoodDonationContext : IdentityDbContext<User>
    {
        public FoodDonationContext(DbContextOptions<FoodDonationContext> options)
            : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Additional configuration if needed
    }
}
