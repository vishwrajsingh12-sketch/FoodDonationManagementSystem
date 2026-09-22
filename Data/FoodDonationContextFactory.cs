using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FoodDonationManagementSystem.Data
{
    public class FoodDonationContextFactory : IDesignTimeDbContextFactory<FoodDonationContext>
    {
        public FoodDonationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FoodDonationContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=FoodDonationDB;Trusted_Connection=True;MultipleActiveResultSets=true"
            );

            return new FoodDonationContext(optionsBuilder.Options);
        }
    }
}