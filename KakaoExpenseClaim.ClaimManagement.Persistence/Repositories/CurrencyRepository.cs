using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Repositories
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ExpenseClaimDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsEventNameAndSymbolUnique(string name, string symbol)
        {
            var matches = _dbContext.Currencies.Any(e => e.Name.Equals(name) && e.Symbol.Equals(symbol));
            return Task.FromResult(matches);
        }
    }
}
