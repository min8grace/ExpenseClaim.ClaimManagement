using FluentValidation;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.UpdateExpenseClaim;
using System;

namespace GKakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.UpdateExpenseClaim
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateExpenseClaimCommand>
    {
        public UpdateItemCommandValidator()
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
