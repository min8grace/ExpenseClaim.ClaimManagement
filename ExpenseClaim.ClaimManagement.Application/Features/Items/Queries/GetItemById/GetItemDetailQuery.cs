using MediatR;
using System;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById
{
    public class GetItemDetailQuery : IRequest<ItemDetailVm>
    {
        public int Id { get; set; }
    }
}
