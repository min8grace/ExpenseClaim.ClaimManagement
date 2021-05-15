using KakaoExpenseClaim.ClaimManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KakaoExpenseClaim.ClaimManagement.Identity
{
    public class ExpenseClaimIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExpenseClaimIdentityDbContext(DbContextOptions<ExpenseClaimIdentityDbContext> options) : base(options)
        {
        }
    }
}
