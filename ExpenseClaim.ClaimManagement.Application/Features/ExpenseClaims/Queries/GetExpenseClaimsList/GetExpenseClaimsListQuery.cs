using MediatR;
using System.Collections.Generic;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesList
{
    public class GetExpenseClaimsListQuery : IRequest<List<ExpenseClaimListVm>>
    {
    }
}
