using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandHandler : IRequestHandler<CreateExpenseClaimCommand, CreateExpenseClaimCommandResponse>
    {
        private readonly IExpenseClaimRepository _expenseClaimRepository;
        private readonly IMapper _mapper;

        public CreateExpenseClaimCommandHandler(IMapper mapper, IExpenseClaimRepository expenseClaimRepository)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<CreateExpenseClaimCommandResponse> Handle(CreateExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            var createExpenseClaimCommandResponse = new CreateExpenseClaimCommandResponse();

            var validator = new CreateExpenseClaimCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
            {
                createExpenseClaimCommandResponse.Success = false;
                createExpenseClaimCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createExpenseClaimCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createExpenseClaimCommandResponse.Success)
            {
                var expenseClaim = _mapper.Map<ExpenseClaim>(request);
                expenseClaim = await _expenseClaimRepository.AddAsync(expenseClaim);
                createExpenseClaimCommandResponse.ExpenseClaim = _mapper.Map<CreateExpenseClaimDto>(expenseClaim);
            }

            return createExpenseClaimCommandResponse;
        }
    }
}
