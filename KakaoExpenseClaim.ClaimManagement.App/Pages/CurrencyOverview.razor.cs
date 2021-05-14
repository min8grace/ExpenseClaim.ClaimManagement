using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Pages
{
    public partial class CurrencyOverview
    {
        [Inject]
        public ICurrencyDataService CurrencyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CurrencyViewModel> Currencies { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Currencies = await CurrencyDataService.GetAllCurrencies();
        }
    }
}
