using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesListWithEvents
{
    public class GetExpenseClaimsWithItemsQueryHandler : IRequestHandler<GetExpenseClaimsWithItemsQuery, List<ExpenseClaimItemListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseClaimRepository _expenseClaimRepository;

        public GetExpenseClaimsWithItemsQueryHandler(IMapper mapper, IExpenseClaimRepository expenseClaimRepository)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<List<ExpenseClaimItemListVm>> Handle(GetExpenseClaimsWithItemsQuery request, CancellationToken cancellationToken)
        {
            var list = await _expenseClaimRepository.GetExpenseClaimsWithItems(request.IncludeHistory);
            return _mapper.Map<List<ExpenseClaimItemListVm>>(list);

        }
    }
}
