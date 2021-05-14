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

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IAsyncRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public DeleteItemCommandHandler(IMapper mapper, IAsyncRepository<Item> itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _itemRepository.GetByIdAsync(request.ItemId);
            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Item), request.ItemId);
            }
            await _itemRepository.DeleteAsync(itemToDelete);

            return Unit.Value; //default value
        }
    }
}
