using KakaoExpenseClaim.ClaimManagement.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.ViewModels
{
    public class PagedClaimForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<ExpenseClaimItemsViewModel> ClaimsForMonth { get; set; }
    }
}
