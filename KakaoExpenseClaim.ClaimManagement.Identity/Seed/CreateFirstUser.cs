using KakaoExpenseClaim.ClaimManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "EmployeeA",
                LastName = "EmployeeA",
                UserName = "21000173",
                Email = "EmployeeA@ABC.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Abcd&01?");
            }

            var applicationUser1 = new ApplicationUser
            {
                FirstName = "EmployeeB",
                LastName = "EmployeeB",
                UserName = "21000986",
                Email = "EmployeeB@ABC.com",
                EmailConfirmed = true
            };

            var user1 = await userManager.FindByEmailAsync(applicationUser1.Email);
            if (user1 == null)
            {
                await userManager.CreateAsync(applicationUser1, "Abcd&01?");
            }

            var applicationUser2 = new ApplicationUser
            {
                FirstName = "EmployeeC",
                LastName = "EmployeeC",
                UserName = "21000319",
                Email = "EmployeeC@ABC.com",
                EmailConfirmed = true
            };

            var user2 = await userManager.FindByEmailAsync(applicationUser2.Email);
            if (user2 == null)
            {
                await userManager.CreateAsync(applicationUser2, "Abcd&01?");
            }

            var applicationUser3 = new ApplicationUser
            {
                FirstName = "EmployeeD",
                LastName = "EmployeeD",
                UserName = "21000812",
                Email = "EmployeeD@ABC.com",
                EmailConfirmed = true
            };

            var user3 = await userManager.FindByEmailAsync(applicationUser3.Email);
            if (user3 == null)
            {
                await userManager.CreateAsync(applicationUser3, "Abcd&01?");
            }

            var applicationUser4 = new ApplicationUser
            {
                FirstName = "EmployeeE",
                LastName = "EmployeeE",
                UserName = "21000546",
                Email = "EmployeeE@ABC.com",
                EmailConfirmed = true
            };

            var user4 = await userManager.FindByEmailAsync(applicationUser4.Email);
            if (user4 == null)
            {
                await userManager.CreateAsync(applicationUser4, "Abcd&01?");
            }

            var applicationUser5 = new ApplicationUser
            {
                FirstName = "Approver",
                LastName = "Approver",
                UserName = "51000412",
                Email = "Approver@ABC.com",
                EmailConfirmed = true
            };

            var user5 = await userManager.FindByEmailAsync(applicationUser5.Email);
            if (user5 == null)
            {
                await userManager.CreateAsync(applicationUser5, "Abcd&01?");
            }

            var applicationUser6 = new ApplicationUser
            {
                FirstName = "FinanceDep",
                LastName = "FinanceDep",
                UserName = "71000977",
                Email = "FinanceDep@ABC.com",
                EmailConfirmed = true
            };

            var user6 = await userManager.FindByEmailAsync(applicationUser6.Email);
            if (user6 == null)
            {
                await userManager.CreateAsync(applicationUser6, "Abcd&01?");
            }
        }
    }
}