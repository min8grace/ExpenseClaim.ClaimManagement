using AutoMapper;
using Blazored.LocalStorage;
using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Services
{
    public class ItemDataService : BaseDataService, IItemDataService
    {
        private readonly IMapper _mapper;
        public ItemDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ItemViewModel>> GetAllItems(int id)
        {
            await AddBearerToken();

            var allItems = await _client.GetAllItemsAsync(id);
            var mappedItems = _mapper.Map<ICollection<ItemViewModel>>(allItems);
            return mappedItems.ToList();
        }

        public async Task<ItemDetailViewModel> GetItemById(int id)
        {
            await AddBearerToken();

            var selectedtItem = await _client.GetItemByIdAsync(id);
            var mappedtItem = _mapper.Map<ItemDetailViewModel>(selectedtItem);
            return mappedtItem;
        }
        public async Task<ApiResponse<int>> CreateItem(ItemViewModel itemDetailViewModel)
        {
            try
            { 
                
                CreateItemCommand createItemCommand = _mapper.Map<CreateItemCommand>(itemDetailViewModel);
                var reponse = await _client.AddItemAsync(createItemCommand);
                return new ApiResponse<int>() { Data = reponse.Item.ItemId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateItem(ItemDetailViewModel itemDetailViewModel)
        {
            try
            {
                UpdateItemCommand updateItemCommand = _mapper.Map<UpdateItemCommand>(itemDetailViewModel);
                await _client.UpdateItemAsync(updateItemCommand);
                return new ApiResponse<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }


        public async Task<ApiResponse<int>> DeleteItem(int id)
        {
            try
            {
                await _client.DeleteItemAsync(id);
                return new ApiResponse<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
