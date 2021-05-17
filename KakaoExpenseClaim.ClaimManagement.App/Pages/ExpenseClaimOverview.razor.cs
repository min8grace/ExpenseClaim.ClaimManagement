using KakaoExpenseClaim.ClaimManagement.App.Auth;
using KakaoExpenseClaim.ClaimManagement.App.Components;
using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class ExpenseClaimOverview
    {
        [Inject]
        public IExpenseClaimDataService ExpenseClaimDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        public string SelectedMonth { get; set; } = String.Concat(DateTime.Now.Month).Length > 1 ? String.Concat(DateTime.Now.Month) : "0" + String.Concat(DateTime.Now.Month);
        public string SelectedYear { get; set; } = String.Concat(DateTime.Now.Year);

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> YearList { get; set; } = new List<string>() { "2020", "2021", "2022" };

        private int? pageNumber = 1;

        private PaginatedList<ExpenseClaimItemsViewModel> paginatedList
            = new PaginatedList<ExpenseClaimItemsViewModel>();

        private IEnumerable<ExpenseClaimItemsViewModel> ExpenseClaimsList;

        public ICollection<ExpenseClaimItemsViewModel> ExpenseClaims { get; set; }
        public ICollection<PagedClaimForMonthViewModel> PagedExpenseClaims { get; set; }
        public AuthenticationState authenticationState;
        private string Username = "Anonymous User";
        protected async override Task OnInitializedAsync()
        {
            authenticationState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
            Username =
            authenticationState.User.Claims
            .Where(c => c.Type.Equals("sub"))
            .Select(c => c.Value)
            .FirstOrDefault() ?? string.Empty;
            
            //Requested = 1, Approved = 2, Rejected = 3, Queried = 4, Processing = 5, RejectedByFinance = 7, Finished = 8, Cancel = 9, Saved = 99
            ExpenseClaimsList = (await ExpenseClaimDataService.GetExpenseClaimsWithItems(false));

            if (Username[0].Equals('5')) // Approver
                ExpenseClaimsList = ExpenseClaimsList.Where(x => x.Status == Services.Status.Approved);
            else if (Username[0].Equals('7')) // Finance Dept
                ExpenseClaimsList = ExpenseClaimsList.Where(x => x.Status == Services.Status.Processing);
            else if (Username[0].Equals('2')) // employees
                ExpenseClaimsList = ExpenseClaimsList.Where(x => x.RequesterId == int.Parse(Username));
            else if (Username[0].Equals('9')) // administrator
                { }
            else // others
                ExpenseClaimsList = null;
        }

        protected async Task GetExpenseClaims()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var Claims = await ExpenseClaimDataService.GetPagedClaimForMonth(dt, pageNumber.Value, 5);
            paginatedList = new PaginatedList<ExpenseClaimItemsViewModel>(Claims.ClaimsForMonth.ToList(), Claims.Count, pageNumber.Value, 5);
            ExpenseClaimsList = paginatedList.Items;

            StateHasChanged();
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportClaims()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:44359/api/ExpenseClaim/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }

        protected void AddNewClaim()
        {
            NavigationManager.NavigateTo("/expenseclaimdetail");
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
