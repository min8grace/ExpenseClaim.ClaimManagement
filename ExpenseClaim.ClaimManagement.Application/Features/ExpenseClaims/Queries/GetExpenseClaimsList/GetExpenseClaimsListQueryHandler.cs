using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesList
{
    public class GetExpenseClaimsListQueryHandler : IRequestHandler<GetExpenseClaimsListQuery, List<ExpenseClaimListVm>>
    {
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimsRepository;
        private readonly IMapper _mapper;

        public GetExpenseClaimsListQueryHandler(IMapper mapper, IAsyncRepository<ExpenseClaim> expenseClaimsRepository)
        {
            _mapper = mapper;
            _expenseClaimsRepository = expenseClaimsRepository;
        }

        public async Task<List<ExpenseClaimListVm>> Handle(GetExpenseClaimsListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _expenseClaimsRepository.ListAllAsync()).OrderBy(x => x.SubmitDate);
            return _mapper.Map<List<ExpenseClaimListVm>>(allCategories);
        }
    }
}
