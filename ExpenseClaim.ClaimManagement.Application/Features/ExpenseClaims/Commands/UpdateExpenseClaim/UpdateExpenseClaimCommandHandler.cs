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

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.UpdateExpenseClaim
{
    public class UpdateExpenseClaimCommandHandler : IRequestHandler<UpdateExpenseClaimCommand>
    {
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimRepository;
        private readonly IMapper _mapper;

        public UpdateExpenseClaimCommandHandler(IMapper mapper, IAsyncRepository<ExpenseClaim> expenseClaimRepository)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<Unit> Handle(UpdateExpenseClaimCommand request, CancellationToken cancellationToken)
        {

            var currencyToUpdate = await _expenseClaimRepository.GetByIdAsync(request.ExpenseClaimId);

            _mapper.Map(request, currencyToUpdate, typeof(UpdateExpenseClaimCommand), typeof(ExpenseClaim));

            await _expenseClaimRepository.UpdateAsync(currencyToUpdate);

            return Unit.Value;
        }
    }
}
