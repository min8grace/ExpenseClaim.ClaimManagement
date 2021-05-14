using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Application.Exceptions;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.DeleteExpenseClaim
{
    public class DeleteExpenseClaimCommandHandler : IRequestHandler<DeleteExpenseClaimCommand>
    {
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimRepository;
        private readonly IMapper _mapper;

        public DeleteExpenseClaimCommandHandler(IMapper mapper, IAsyncRepository<ExpenseClaim> expenseClaimRepository)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<Unit> Handle(DeleteExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            var expenseClaimToDelete = await _expenseClaimRepository.GetByIdAsync(request.ExpenseClaimId);

            if (expenseClaimToDelete == null)
            {
                throw new NotFoundException(nameof(ExpenseClaim), request.ExpenseClaimId);
            }

            await _expenseClaimRepository.DeleteAsync(expenseClaimToDelete);

            return Unit.Value; //default value
        }
    }
}
