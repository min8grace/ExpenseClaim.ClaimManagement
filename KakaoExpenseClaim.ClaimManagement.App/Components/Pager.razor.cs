using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Components
{
    public partial class Pager
    {
        [Parameter]
        public int PageIndex { get; set; }

        [Parameter]
        public int TotalPages { get; set; }

        [Parameter]
        public bool HasPreviousPage { get; set; }

        [Parameter]
        public bool HasNextPage { get; set; }

        [Parameter]
        public EventCallback<int> OnClick { get; set; }
    }
}
