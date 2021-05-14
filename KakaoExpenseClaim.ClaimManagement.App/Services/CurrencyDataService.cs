using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using AutoMapper;
using Blazored.LocalStorage;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;

namespace KakaoExpenseClaim.ClaimManagement.App.Services
{
    public class CurrencyDataService : BaseDataService, ICurrencyDataService
    {
        private readonly IMapper _mapper;
        public CurrencyDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CurrencyViewModel>> GetAllCurrencies()
        {
            //await AddBearerToken();

            var allCurrencies = await _client.GetAllCurrenciesAsync();
            var mappedCurrencies = _mapper.Map<ICollection<CurrencyViewModel>>(allCurrencies);
            
            return mappedCurrencies.ToList();
        }
    }
}
