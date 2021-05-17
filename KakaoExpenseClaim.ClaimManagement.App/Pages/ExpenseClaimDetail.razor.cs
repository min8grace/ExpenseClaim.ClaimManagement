using KakaoExpenseClaim.ClaimManagement.App.Auth;
using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class ExpenseClaimDetail
    {
        [Inject]
        public IExpenseClaimDataService ExpenseClaimDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public ExpenseClaimDetailViewModel ExpenseClaimDetailViewModel { get; set; }
            = new ExpenseClaimDetailViewModel() { SubmitDate = DateTime.Now.AddDays(1) };

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string ExpenseClaimid { get; set; }
        private int SelectedExpenseClaimId = 0;
        private int CreatedExpenseClaimId = 0;
        public AuthenticationState authenticationState;
        private string Username = "Anonymous User";
        protected override async Task OnInitializedAsync()
        {
            authenticationState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
            Username =
            authenticationState.User.Claims
            .Where(c => c.Type.Equals("sub"))
            .Select(c => c.Value)
            .FirstOrDefault() ?? string.Empty;
            if (int.TryParse(ExpenseClaimid, out SelectedExpenseClaimId))            
                ExpenseClaimDetailViewModel = await ExpenseClaimDataService.GetExpenseClaimById(SelectedExpenseClaimId);            
            else
                ExpenseClaimDetailViewModel.RequesterId = int.Parse(Username);
        }

        protected async Task HandleValidSubmit()
        {
            ApiResponse<int> response;

            if (SelectedExpenseClaimId == 0)
            {
                response = await ExpenseClaimDataService.CreateExpenseClaim(ExpenseClaimDetailViewModel);               
            }
            else
            {
                response = await ExpenseClaimDataService.UpdateExpenseClaim(ExpenseClaimDetailViewModel);
            }

            HandleResponse(response);
        }

        protected async Task DeleteExpenseClaim()
        {
            var response = await ExpenseClaimDataService.DeleteExpenseClaim(SelectedExpenseClaimId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/expenseclaimoverview");
        }

        private ItemOverview itemOverview;
        private void HandleResponse(ApiResponse<int> response)
        {      
            if (response.Success)
            {
                CreatedExpenseClaimId = response.Data;
                itemOverview.CreateItems(response.Data);             
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
