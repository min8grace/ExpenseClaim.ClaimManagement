using KakaoExpenseClaim.ClaimManagement.App.Services;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.ViewModels
{
    public class ExpenseClaimViewModel
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

    }
}
