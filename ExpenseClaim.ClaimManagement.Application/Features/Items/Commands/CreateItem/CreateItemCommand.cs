using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<CreateItemCommandResponse>
    {
        public int CategoryId { get; set; }
        public int PayeeId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public Decimal USDAmount { get; set; }
        public string Description { get; set; }
        
        public byte[] Receipt { get; set; }
        public int ExpenseClaimId { get; set; }
        public override string ToString()
        {
            return $"CategoryId: {CategoryId}; PayeeId: {PayeeId}; Price: {USDAmount}; ExpenseClaimId: {ExpenseClaimId}; " +
                $"On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
