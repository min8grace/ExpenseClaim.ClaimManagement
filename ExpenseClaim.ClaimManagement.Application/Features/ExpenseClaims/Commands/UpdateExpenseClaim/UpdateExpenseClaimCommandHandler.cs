using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Application.Exceptions;
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

            var expenseClaimyToUpdate = await _expenseClaimRepository.GetByIdAsync(request.ExpenseClaimId);

            if (expenseClaimyToUpdate == null)
            {
                throw new NotFoundException(nameof(ExpenseClaim), request.ExpenseClaimId);
            }

            var validator = new UpdateExpenseClaimCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            _mapper.Map(request, expenseClaimyToUpdate, typeof(UpdateExpenseClaimCommand), typeof(ExpenseClaim));

            await _expenseClaimRepository.UpdateAsync(expenseClaimyToUpdate);

            return Unit.Value;
        }
    }
}
