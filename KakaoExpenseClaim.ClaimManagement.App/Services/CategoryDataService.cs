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
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;
        public CategoryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            await AddBearerToken();

            var allCategories = await _client.GetAllCategoriesAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);          

            return mappedCategories.ToList();
        }
    }
}
