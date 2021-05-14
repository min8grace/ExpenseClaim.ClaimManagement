using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<ItemListVm>>
    {
        private readonly IAsyncRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsListQueryHandler(IMapper mapper, IAsyncRepository<Item> itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemListVm>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == 0)
            {
                var allItems = (await _itemRepository.ListAllAsync()).OrderBy(x => x.Date);
                return _mapper.Map<List<ItemListVm>>(allItems);
            }                
            else
            {
                var allItems = (await _itemRepository.ListAllAsync()).Where(x => x.ExpenseClaimId.Equals(request.Id)).OrderBy(x => x.Date);
                return _mapper.Map<List<ItemListVm>>(allItems);
            }
        }
    }
}
