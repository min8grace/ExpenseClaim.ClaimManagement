using KakaoExpenseClaim.ClaimManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public CreateItemCommandResponse(): base()
        {

        }

        public CreateItemDto Item { get; set; }
    }
}
