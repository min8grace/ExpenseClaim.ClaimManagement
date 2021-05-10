using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
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
        private readonly IAsyncRepository<Item> _ItemRepository;
        private readonly IMapper _mapper;

        public DeleteItemCommandHandler(IMapper mapper, IAsyncRepository<Item> ItemRepository)
        {
            _mapper = mapper;
            _ItemRepository = ItemRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var ItemToDelete = await _ItemRepository.GetByIdAsync(request.ItemId);

            await _ItemRepository.DeleteAsync(ItemToDelete);

            return Unit.Value; //default value
        }
    }
}
