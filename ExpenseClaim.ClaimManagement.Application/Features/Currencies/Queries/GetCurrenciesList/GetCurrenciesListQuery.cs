using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Queries.GetCurrenciesList
{
    public class GetCurrenciesListQuery : IRequest<List<CurrencyListVm>>
    {
    }
}
