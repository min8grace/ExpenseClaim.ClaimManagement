using MediatR;
using System.Collections.Generic;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQuery: IRequest<List<ItemListVm>>
    {
        public int Id { get; set; }
    }
}
