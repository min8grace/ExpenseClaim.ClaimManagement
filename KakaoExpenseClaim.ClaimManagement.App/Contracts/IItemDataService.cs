using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Contracts
{
    public interface IItemDataService
    {
        Task<List<ItemViewModel>> GetAllItems(int id);
        Task<ItemDetailViewModel> GetItemById(int id);
        Task<ApiResponse<int>> CreateItem(ItemViewModel itemDetailViewModel);
        Task<ApiResponse<int>> UpdateItem(ItemDetailViewModel itemClaimDetailViewModel);
        Task<ApiResponse<int>> DeleteItem(int id);
    }
}
