using FluentValidation;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCurrencyCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(CategoryNameAndCodeUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> CategoryNameAndCodeUnique(CreateCategoryCommand e, CancellationToken token)
        {
            return !(await _categoryRepository.IsEventNameAndCodeUnique(e.Name, e.Code));
        }
    }
}
