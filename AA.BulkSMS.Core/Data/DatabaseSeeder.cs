using AA.BulkSMS.Core.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AA.BulkSMS.Core.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            string[] roles = { "Super User", "Company Administrator", "Company Manager", "Company Exco", "Company Supervisor", "Company General User" };

            // Ensure roles exist
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create a default Super User
            if (!userManager.Users.Any(u => u.Email == "admin@saas.com"))
            {
                var adminUser = new SystemUser
                {
                    UserName = "admin",
                    Email = "admin@saas.com",
                    EmailConfirmed = true,
                    FirstName = "Super",
                    OtherNames = "Admin",
                    LastName = "User",
                    OrganisationId = "ffc0735f-a0e7-49cb-bd8c-10984ed6a0eb", // Super Users linked to Afrolynx
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Super User");
                }
            }
        }
    }
}
