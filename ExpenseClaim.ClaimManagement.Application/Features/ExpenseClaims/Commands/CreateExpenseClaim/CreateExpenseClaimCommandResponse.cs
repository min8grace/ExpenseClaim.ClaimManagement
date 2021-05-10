using KakaoExpenseClaim.ClaimManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandResponse : BaseResponse
    {
        public CreateExpenseClaimCommandResponse(): base()
        {

        }

        public CreateExpenseClaimDto ExpenseClaim { get; set; }
    }
}
