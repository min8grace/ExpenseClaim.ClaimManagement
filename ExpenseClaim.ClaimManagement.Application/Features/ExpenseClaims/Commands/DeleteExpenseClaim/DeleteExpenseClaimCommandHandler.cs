using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var eventToDelete = await _expenseClaimRepository.GetByIdAsync(request.ExpenseClaimId);

            await _expenseClaimRepository.DeleteAsync(eventToDelete);

            return Unit.Value; //default value
        }
    }
}
