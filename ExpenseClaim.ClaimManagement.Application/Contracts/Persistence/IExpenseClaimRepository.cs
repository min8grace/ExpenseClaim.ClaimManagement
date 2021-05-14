using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence
{
    public interface IExpenseClaimRepository : IAsyncRepository<ExpenseClaim>
    {
        Task<List<ExpenseClaim>> GetExpenseClaimsWithItems(bool includePassedOnes);
        Task<List<ExpenseClaim>> GetPagedClaimsForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountOfClaimsForMonth(DateTime date);
    }
}
