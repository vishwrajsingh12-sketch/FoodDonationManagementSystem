using FoodDonationManagementSystem.Data;
using FoodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Database
builder.Services.AddDbContext<FoodDonationContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FoodDonationContext>()
    .AddDefaultTokenProviders();


// MVC
builder.Services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    await RoleSeeder.SeedRoles(roleManager);
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();