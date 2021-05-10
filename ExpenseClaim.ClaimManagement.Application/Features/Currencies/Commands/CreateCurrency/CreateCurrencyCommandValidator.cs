using FluentValidation;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateCurrency
{
    public class UpdateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;
        public UpdateCurrencyCommandValidator(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(CurrencyNameAndCodeUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Symbol)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> CurrencyNameAndCodeUnique(CreateCurrencyCommand e, CancellationToken token)
        {
            return !(await _currencyRepository.IsEventNameAndSymbolUnique(e.Name, e.Symbol));
        }
    }
}
