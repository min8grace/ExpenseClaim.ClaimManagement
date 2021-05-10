using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence
{
    public interface ICurrencyRepository : IAsyncRepository<Currency>
    {
        Task<bool> IsEventNameAndSymbolUnique(string name, string symbol);
    }
}
