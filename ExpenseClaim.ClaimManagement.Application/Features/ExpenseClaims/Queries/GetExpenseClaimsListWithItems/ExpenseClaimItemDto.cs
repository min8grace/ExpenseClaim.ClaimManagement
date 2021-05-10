using System;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsListWithItems
{
    public class ExpenseClaimItemDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}
