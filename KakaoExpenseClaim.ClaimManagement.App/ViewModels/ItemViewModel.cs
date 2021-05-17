using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KakaoExpenseClaim.ClaimManagement.App.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; } 
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public int PayeeId { get; set; } 
        public DateTime Date { get; set; } 
        public Decimal Amount { get; set; }
        public int CurrencyId { get; set; } 
        public string CurrencyName { get; set; }
        public Decimal USDAmount { get; set; } 
        public string Description { get; set; }
        public byte[] Receipt { get; set; } 
        public int ExpenseClaimId { get; set; }

        public override string ToString()
        {
            return $"{ExpenseClaimId} - {ItemId}";
        }
    }
}
