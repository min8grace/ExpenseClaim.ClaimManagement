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

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {

        private readonly IItemRepository _ItemRepository;
        private readonly IMapper _mapper;


        public CreateItemCommandHandler(IMapper mapper, IItemRepository ItemRepository)
        {
            _mapper = mapper;
            _ItemRepository = ItemRepository;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var @Item = _mapper.Map<Item>(request);

            @Item = await _ItemRepository.AddAsync(@Item);

            return @Item.ItemId;
        }
    }
}
