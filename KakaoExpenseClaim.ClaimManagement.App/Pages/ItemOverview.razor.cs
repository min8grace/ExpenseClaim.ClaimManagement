using KakaoExpenseClaim.ClaimManagement.App.Contracts;
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

        public ICollection<ItemViewModel> Items { get; set; }
        protected async override Task OnInitializedAsync()
        {
            //int.TryParse(ExpenseClaimid, out SelectedExpenseClaimId);
            Items = await ItemDataService.GetAllItems(SelectedExpenseClaimId);
            var listCtgr = await CategoryDataService.GetAllCategories();
            var listCurr = await CurrencyDataService.GetAllCurrencies();

            foreach (var it in Items)
            {                
                it.CategoryName = listCtgr.Find(x => x.Id == it.CategoryId).Name;
                it.CurrencyName = listCurr.Find(x => x.Id == it.CurrencyId).Name;
            }           
        }
    }
}
