using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Symbol: {Symbol}; ";
        }
    }
}
