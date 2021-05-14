using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace KakaoExpenseClaim.ClaimManagement.App.ViewModels
{
    public class ItemDetailViewModel
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int PayeeId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be a positive value")]
        public Decimal Amount { get; set; }
        public int CurrencyId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be a positive value")]
        public Decimal USDAmount { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")]
        public string Description { get; set; }
        public byte[] Receipt { get; set; }
        public int ExpenseClaimId { get; set; }
    }
}
