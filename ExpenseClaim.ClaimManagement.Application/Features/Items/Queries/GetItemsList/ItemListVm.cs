using System;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList
{
    public class ItemListVm
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
    }
}
