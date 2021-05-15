using KakaoExpenseClaim.ClaimManagement.App.Components;
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

        public string SelectedMonth { get; set; } = String.Concat(DateTime.Now.Month).Length > 1 ? String.Concat(DateTime.Now.Month) : "0"+String.Concat(DateTime.Now.Month);
        public string SelectedYear { get; set; } = String.Concat(DateTime.Now.Year);

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> YearList { get; set; } = new List<string>() { "2020", "2021", "2022" };

        private int? pageNumber = 1;

        private PaginatedList<ExpenseClaimItemsViewModel> paginatedList
            = new PaginatedList<ExpenseClaimItemsViewModel>();

        private IEnumerable<ExpenseClaimItemsViewModel> ExpenseClaimsList;

        public ICollection<ExpenseClaimItemsViewModel> ExpenseClaims { get; set; }
        public ICollection<PagedClaimForMonthViewModel> PagedExpenseClaims { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ExpenseClaimsList = await ExpenseClaimDataService.GetExpenseClaimsWithItems(false);
        }

        protected async Task GetExpenseClaims()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var Claims = await ExpenseClaimDataService.GetPagedClaimForMonth(dt, pageNumber.Value, 5);
            paginatedList = new PaginatedList<ExpenseClaimItemsViewModel>(Claims.ClaimsForMonth.ToList(), Claims.Count, pageNumber.Value, 5);
            ExpenseClaimsList = paginatedList.Items;

            StateHasChanged();
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

        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            await GetExpenseClaims();
            StateHasChanged();
        }
    }
}
