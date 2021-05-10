using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Queries.GetCurrenciesList
{
    public class CurrencyListVm
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
