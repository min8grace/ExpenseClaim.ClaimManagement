using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Application.Models.Mail;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using MediatR;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandHandler : IRequestHandler<CreateExpenseClaimCommand, CreateExpenseClaimCommandResponse>
    {
        private readonly IExpenseClaimRepository _expenseClaimRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateExpenseClaimCommandHandler> _logger;

        public CreateExpenseClaimCommandHandler(IMapper mapper, IExpenseClaimRepository expenseClaimRepository, IEmailService emailService, ILogger<CreateExpenseClaimCommandHandler> logger)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
            _emailService = emailService;
            _logger = logger;
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

            //Sending email notification to admin address
            var email = new Email() { To = "dave@test.com", Body = $"A new ExpenseClaim was created: {request}", Subject = "A new ExpenseClaim was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about ExpenseClaim {createExpenseClaimCommandResponse.ExpenseClaim.ExpenseClaimId} failed due to an error with the mail service: {ex.Message}");
            }


            return createExpenseClaimCommandResponse;
        }
    }
}
