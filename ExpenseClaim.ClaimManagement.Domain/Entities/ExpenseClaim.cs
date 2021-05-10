using KakaoExpenseClaim.ClaimManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KakaoExpenseClaim.ClaimManagement.Domain.Entities
{

    public enum Status
    {
        Requested = 1, Approved = 2, Rejected = 3, Queried = 4, Processing = 5, RejectedByFinance = 7, Finished = 8, Cancel = 9, Saved = 99
    }
    public class ExpenseClaim : AuditableEntity
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

        public virtual ICollection<Item> Items { get; set; }
    }
}
