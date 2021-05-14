using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class ItemDetail
    {
        [Inject]
        public IItemDataService ItemDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public ICurrencyDataService CurrencyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ItemDetailViewModel ItemDetailViewModel { get; set; }
            = new ItemDetailViewModel() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }
            = new ObservableCollection<CurrencyViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }
        public string SelectedCurrencyId { get; set; }

        [Parameter]
        public string ItemId { get; set; }
        private int SelectedItemId = 0;

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(ItemId, out SelectedItemId);
            var listCtgr = await CategoryDataService.GetAllCategories();
            var listCurr = await CurrencyDataService.GetAllCurrencies();
            Categories = new ObservableCollection<CategoryViewModel>(listCtgr);
            Currencies = new ObservableCollection<CurrencyViewModel>(listCurr);

            if (SelectedItemId > 0)
            {
                ItemDetailViewModel = await ItemDataService.GetItemById(SelectedItemId);
                SelectedCategoryId = ItemDetailViewModel.CategoryId.ToString();
                SelectedCurrencyId = ItemDetailViewModel.CurrencyId.ToString();
            }
            else
            {                
                SelectedCategoryId = Categories.FirstOrDefault().Id.ToString();
                SelectedCurrencyId = Currencies.FirstOrDefault().Id.ToString();
            } 
        }

        protected async Task HandleValidSubmit()
        {
            ItemDetailViewModel.CategoryId = int.Parse(SelectedCategoryId);
            ItemDetailViewModel.CurrencyId = int.Parse(SelectedCurrencyId);
            ApiResponse<int> response;

            if (SelectedItemId == 0)
            {
                response = await ItemDataService.CreateItem(ItemDetailViewModel);
            }
            else
            {
                response = await ItemDataService.UpdateItem(ItemDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeleteItem()
        {
            var response = await ItemDataService.DeleteItem(SelectedItemId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo($"/expenseclaimoverview");
        }

        private void HandleResponse(ApiResponse<int> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo($"/expenseclaimoverview");
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
