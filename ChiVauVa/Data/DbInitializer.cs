using ChiVauVa.Models;
using Microsoft.AspNetCore.Identity;

namespace ChiVauVa.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Создание ролей
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Создание администратора

            var admin = new ApplicationUser
            {
                UserName = "ivanov@mail.com",
                Email = "ivanov@mail.com",
                PhoneNumber = "79161234567"
            };

            await userManager.CreateAsync(admin, "pass123");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

    }
}
