using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Contracts
{
    public interface ICurrencyDataService
    {
        Task<List<CurrencyViewModel>> GetAllCurrencies();
    }
}
