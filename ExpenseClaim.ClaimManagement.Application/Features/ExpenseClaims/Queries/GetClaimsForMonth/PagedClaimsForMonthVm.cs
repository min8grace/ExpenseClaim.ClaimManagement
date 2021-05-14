using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetClaimsForMonth
{
    public class PagedClaimsForMonthVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<ClaimsForMonthDto> ClaimsForMonth { get; set; }
    }
}
