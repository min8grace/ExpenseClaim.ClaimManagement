using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class ExpenseClaimOverview
    {
        [Inject]
        public IExpenseClaimDataService ExpenseClaimDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ExpenseClaimItemsViewModel> ExpenseClaims { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ExpenseClaims = await ExpenseClaimDataService.GetExpenseClaimsWithItems(false);
        }
        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if ((bool)args.Value)
            {
                ExpenseClaims = await ExpenseClaimDataService.GetExpenseClaimsWithItems(true);
            }
            else
            {
                ExpenseClaims = await ExpenseClaimDataService.GetExpenseClaimsWithItems(false);
            }    
        }
    }
}
