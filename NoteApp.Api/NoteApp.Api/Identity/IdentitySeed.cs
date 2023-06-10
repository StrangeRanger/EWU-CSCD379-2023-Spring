using Microsoft.AspNetCore.Identity;
using NoteApp.Api.Data;

namespace NoteApp.Api.Identity;

public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        if (!await roleManager.RoleExistsAsync(Roles.Standard))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Standard));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@example.com") == null)
        {
            var user = new AppUser {
                
                UserName = "Admin",
                Email = "Admin@example.com",
            };

            var result = userManager.CreateAsync(user, "another gorse fanfare flyblown").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Standard);
            }
        }
    }
}
