using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ExpenseClaimDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsEventNameAndCodeUnique(string name, string code)
        {
            var matches = _dbContext.Categories.Any(e => e.Name.Equals(name) && e.Code.Equals(code));
            return Task.FromResult(matches);
        }
    }
}
