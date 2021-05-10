using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsListWithItems;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesListWithEvents
{
    public class ExpenseClaimItemListVm
    {
        public int ExpenseClaimId { get; set; }
        public string Title { get; set; }
        public Decimal TotalAmount { get; set; }
        public Status Status { get; set; }

        public int RequesterId { get; set; }
        public DateTime SubmitDate { get; set; }
        public string RequesterComments { get; set; }

        public int ApproverId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApproverComments { get; set; }

        public int FinanceId { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string FinanceComments { get; set; }

        public virtual ICollection<Item> LineItems { get; set; }
    }
}
