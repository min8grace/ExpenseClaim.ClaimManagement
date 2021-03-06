using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Repositories
{
    public class ExpenseClaimRepository : BaseRepository<ExpenseClaim>, IExpenseClaimRepository
    {
        public ExpenseClaimRepository(ExpenseClaimDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ExpenseClaim>> GetExpenseClaimsWithItems(bool includePassedOnes)
        {
            var allExpenseClaims = await _dbContext.ExpenseClaims.Include(x => x.Items).ToListAsync();
            if (!includePassedOnes)
            {
                allExpenseClaims.ForEach(p => p.Items.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allExpenseClaims;
        }

        public async Task<List<ExpenseClaim>> GetPagedClaimsForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.ExpenseClaims.Where(x => x.SubmitDate.Month == date.Month && x.SubmitDate.Year == date.Year)
               .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfClaimsForMonth(DateTime date)
        {
            return await _dbContext.ExpenseClaims.CountAsync(x => x.SubmitDate.Month == date.Month && x.SubmitDate.Year == date.Year);
        }
    }
}
