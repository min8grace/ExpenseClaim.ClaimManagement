using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Application.Exceptions;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.UpdateItem
{
    class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IAsyncRepository<Item> _ItemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IMapper mapper, IAsyncRepository<Item> ItemRepository)
        {
            _mapper = mapper;
            _ItemRepository = ItemRepository;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _ItemRepository.GetByIdAsync(request.ItemId);

            if (itemToUpdate == null)
            {
                throw new NotFoundException(nameof(ExpenseClaim), request.ExpenseClaimId);
            }

            var validator = new UpdateItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, itemToUpdate, typeof(UpdateItemCommand), typeof(Item));


            await _ItemRepository.UpdateAsync(itemToUpdate);

            return Unit.Value;
        }
    }
}
