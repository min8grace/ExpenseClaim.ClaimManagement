using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class ItemOverview
    {
        [Inject]
        public IItemDataService ItemDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ExpenseClaimid { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
        [Inject]
        public ICurrencyDataService CurrencyDataService { get; set; }

        [Parameter]
        public int SelectedExpenseClaimId { get; set; }
        [Parameter]
        public int CreatedExpenseClaimId { get; set; }

        public List<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();

        public int SelectedCategoryId { get; set; } = 0;
        public int SelectedCurrencyId { get; set; } = 0;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }
            = new ObservableCollection<CurrencyViewModel>();
        public string Message { get; set; }
        private bool dense = false;
        private bool hover = true;
        private bool ronly = false;
        private string searchString = "";
        private ItemViewModel selectedItem = null;
        private HashSet<ItemViewModel> selectedItems = new HashSet<ItemViewModel>();
        List<CategoryViewModel> listCtgr;
        List<CurrencyViewModel> listCurr;
        protected async override Task OnInitializedAsync()
        {            
            listCtgr = await CategoryDataService.GetAllCategories();
            listCurr = await CurrencyDataService.GetAllCurrencies();
            Categories = new ObservableCollection<CategoryViewModel>(listCtgr);
            Currencies = new ObservableCollection<CurrencyViewModel>(listCurr);

            if (SelectedExpenseClaimId != 0)
            {
                ronly = true;
                Items = await ItemDataService.GetAllItems(SelectedExpenseClaimId);
                foreach (var it in Items)
                {
                    it.CategoryName = listCtgr.Find(x => x.Id == it.CategoryId).Name;
                    it.CurrencyName = listCurr.Find(x => x.Id == it.CurrencyId).Name;
                    if (it.ItemId == 0)
                    {
                        it.CategoryName = listCtgr[0].Name;
                        it.CurrencyName = listCurr[0].Name;
                    }
                }
            }
        }

        private bool FilterFunc(ItemViewModel element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.CategoryName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.CategoryName} {element.CurrencyName} {element.Description} {element.PayeeId} {element.ItemId}".Contains(searchString))
                return true;
            return false;
        }

        protected async Task AddItem()
        {
            ItemViewModel item = new ItemViewModel();
            item.Date = DateTime.Now;
            item.CategoryId = listCtgr[0].Id;
            item.CategoryName = listCtgr[0].Name;
            item.CurrencyId = listCurr[0].Id;
            item.CurrencyName = listCurr[0].Name;
            Items.Add(item);
        }

        protected async Task DeleteItem(ItemViewModel item)
        {
            Items.Remove(item);
        }


        public async Task CreateItems(int createdExpenseClaimId)
        {
            ApiResponse<int> response = new ApiResponse<int>();
            foreach(var itm in Items)
            {
                itm.ExpenseClaimId = createdExpenseClaimId;
                itm.CategoryId = listCtgr.Find(x => x.Name == itm.CategoryName).Id;
                itm.CurrencyId = listCurr.Find(x => x.Name == itm.CurrencyName).Id;
                response = await ItemDataService.CreateItem(itm);
                if (!response.Success) { HandleResponse(response); break; }
            }            
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<int> response)
        {
            if (response.Success)
            {                
                NavigationManager.NavigateTo("/expenseclaimoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/expenseclaimoverview");
        }
    }
}
