using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim
{
    public class CreateExpenseClaimCommandValidator : AbstractValidator<CreateExpenseClaimCommand>
    {
        public CreateExpenseClaimCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.SubmitDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.TotalAmount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

        }
    }
}
