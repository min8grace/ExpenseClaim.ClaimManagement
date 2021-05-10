using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.DeleteCurrency
{
    public class DeleteCurrencyCommand : IRequest
    {
        public int CurrencyId { get; set; }
    }
}
