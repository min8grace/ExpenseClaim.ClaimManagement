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
    public class ExpenseClaimDetailViewModel
    {
        public int ExpenseClaimId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The title should be 50 characters or less")]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be a positive value")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public Decimal TotalAmount { get; set; }
        public Status Status { get; set; } = Status.Requested;//  Requested = 1, Approved = 2, Rejected = 3, Queried = 4, Processing = 5, RejectedByFinance = 7, Finished = 8, Cancel = 9, Saved = 99

        public int RequesterId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmitDate { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")]
        public string RequesterComments { get; set; }

        public int ApproverId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApprovalDate { get; set; }

        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")]
        public string ApproverComments { get; set; } = " ";

        public int FinanceId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProcessedDate { get; set; }

        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")]
        public string FinanceComments { get; set; } = " ";
    }
}
