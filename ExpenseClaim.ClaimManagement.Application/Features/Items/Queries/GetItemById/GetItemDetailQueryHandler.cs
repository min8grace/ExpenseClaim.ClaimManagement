using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById
{
    public class GetItemDetailQueryHandler : IRequestHandler<GetItemDetailQuery, ItemDetailVm>
    {
        private readonly IAsyncRepository<Item> _itemRepository;
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimRepository;
        private readonly IMapper _mapper;

        public GetItemDetailQueryHandler(IMapper mapper, IAsyncRepository<Item> itemRepository, IAsyncRepository<ExpenseClaim> expenseClaimRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _expenseClaimRepository = expenseClaimRepository;
        }

        public async Task<ItemDetailVm> Handle(GetItemDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _itemRepository.GetByIdAsync(request.Id);
            var itemDetailDto = _mapper.Map<ItemDetailVm>(@item);

            var expenseClaim = await _expenseClaimRepository.GetByIdAsync(@item.ExpenseClaimId);


            itemDetailDto.ExpenseClaim = _mapper.Map<ExpenseClaimDto>(expenseClaim);

            return itemDetailDto;
        }
    }
}
