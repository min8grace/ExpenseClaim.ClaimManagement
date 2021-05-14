using System;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById
{
    public class ItemDetailVm
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int PayeeId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public Decimal USDAmount { get; set; }
        public string Description { get; set; }        
        public byte[] Receipt { get; set; }
        public int ExpenseClaimId { get; set; }
        public ExpenseClaimDto ExpenseClaim { get; set; }
    }
}
