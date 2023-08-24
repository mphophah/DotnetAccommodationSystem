using AMS.Data;
using Microsoft.AspNetCore.Identity;

namespace AMS
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            var users = userManager.GetUsersInRoleAsync("Employee").Result;

            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            if (userManager.FindByNameAsync("employee@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "employee@localhost.com",
                    Email = "employee@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Employee").Wait();
                }
            }
            if (userManager.FindByNameAsync("tenant@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "tenant@localhost.com",
                    Email = "tenant@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Tenant").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Tenant").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Tenant"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
