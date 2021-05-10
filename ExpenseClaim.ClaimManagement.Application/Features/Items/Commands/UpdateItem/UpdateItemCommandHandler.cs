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
            var ItemToUpdate = await _ItemRepository.GetByIdAsync(request.ItemId);
           
            _mapper.Map(request, ItemToUpdate, typeof(UpdateItemCommand), typeof(Item));

            await _ItemRepository.UpdateAsync(ItemToUpdate);

            return Unit.Value;
        }
    }
}
