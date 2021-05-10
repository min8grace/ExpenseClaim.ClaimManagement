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
    public class CreateExpenseClaimCommandHandler : IRequestHandler<CreateExpenseClaimCommand, int>
    {
        private readonly IExpenseClaimRepository _expenseClaimRepository;
        private readonly IMapper _mapper;

        public CreateExpenseClaimCommandHandler(IMapper mapper, IExpenseClaimRepository expenseClaimRepository)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<int> Handle(CreateExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            var @expenseClaim = _mapper.Map<ExpenseClaim>(request);

            @expenseClaim = await _expenseClaimRepository.AddAsync(@expenseClaim);

            return @expenseClaim.ExpenseClaimId;
        }
    }
}
