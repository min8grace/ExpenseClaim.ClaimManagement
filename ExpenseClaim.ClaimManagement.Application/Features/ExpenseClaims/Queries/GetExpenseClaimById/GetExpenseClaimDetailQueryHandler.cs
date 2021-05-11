using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimById
{
    public class GetExpenseClaimDetailQueryHandler : IRequestHandler<GetExpenseClaimDetailQuery, ExpenseClaimDetailVm>
    {
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimsRepository;
        private readonly IMapper _mapper;

        public GetExpenseClaimDetailQueryHandler(IMapper mapper, IAsyncRepository<ExpenseClaim> expenseClaimsRepository)
        {
            _mapper = mapper;
            _expenseClaimsRepository = expenseClaimsRepository;
        }

        public async Task<ExpenseClaimDetailVm> Handle(GetExpenseClaimDetailQuery request, CancellationToken cancellationToken)
        {
            var expenseClaim = await _expenseClaimsRepository.GetByIdAsync(request.Id);
            var expenseClaimDetaiDto = _mapper.Map<ExpenseClaimDetailVm>(expenseClaim);
            
            return expenseClaimDetaiDto;
        }
    }
}
