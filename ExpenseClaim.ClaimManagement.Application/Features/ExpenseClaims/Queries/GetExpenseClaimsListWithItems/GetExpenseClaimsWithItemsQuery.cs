using MediatR;
using System.Collections.Generic;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesListWithEvents
{
    public class GetExpenseClaimsWithItemsQuery : IRequest<List<ExpenseClaimItemListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
