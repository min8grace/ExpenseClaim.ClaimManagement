using KakaoExpenseClaim.ClaimManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace KakaoExpenseClaim.ClaimManagement.Domain.Entities
{
    public class Item : AuditableEntity
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
        public ExpenseClaim ExpenseClaim { get; set; }
    }
}
