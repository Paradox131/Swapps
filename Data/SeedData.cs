using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swapps.Data;
using Swapps.Models;

namespace Swapps.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Ensure DB created
                context.Database.Migrate();

                // --- 1. Seed Donations ---
                if (!context.Donations.Any())
                {
                    context.Donations.AddRange(
                        new Donation { DonorName = "Alice", Amount = 25, Message = "Keep up the great work!" },
                        new Donation { DonorName = "Bob", Amount = 50, Message = "For the community ❤️" },
                        new Donation { DonorName = "Charlie", Amount = 10, Message = "Wish I could give more." }
                    );
                    await context.SaveChangesAsync();
                }

                // --- 2. Seed Admin Role ---
                string adminRole = "Admin";
                if (!await roleManager.RoleExistsAsync(adminRole))
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                // --- 3. Seed Admin User ---
                string adminEmail = "MasterAccount@Hotmail.com";
                string adminPassword = "MasterAccount";

                var adminUser = await userManager.FindByNameAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, adminRole);
                    }
                }
            }
        }
    }
}
public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure DB created
            context.Database.Migrate();

            // --- 1. Seed Donations ---
            if (!context.Donations.Any())
            {
                context.Donations.AddRange(
                    new Donation { DonorName = "Alice", Amount = 25, Message = "Keep up the great work!" },
                    new Donation { DonorName = "Bob", Amount = 50, Message = "For the community ❤️" },
                    new Donation { DonorName = "Charlie", Amount = 10, Message = "Wish I could give more." }
                );
                await context.SaveChangesAsync();
            }

            // --- 2. Seed Admin Role ---
            string adminRole = "Admin";
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // --- 3. Seed Admin User ---
            string adminEmail = "MasterAccount@example.com";
            string adminPassword = "MasterAccount";

            var adminUser = await userManager.FindByNameAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }
}

