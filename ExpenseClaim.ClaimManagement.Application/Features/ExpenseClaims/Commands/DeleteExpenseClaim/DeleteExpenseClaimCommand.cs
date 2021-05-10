using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.DeleteExpenseClaim
{
    public class DeleteExpenseClaimCommand : IRequest
    {
        public int ExpenseClaimId { get; set; }
    }
}
