using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest
    {
        public int ItemId { get; set; }
    }
}
