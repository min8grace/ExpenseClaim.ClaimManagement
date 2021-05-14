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
    public class ExpenseClaimDataService : BaseDataService, IExpenseClaimDataService
    {
        private readonly IMapper _mapper;
        public ExpenseClaimDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ExpenseClaimViewModel>> GetAllExpenseClaims()
        {
            var allExpenseClaims = await _client.GetAllExpenseClaimsAsync();
            var mappedExpenseClaims = _mapper.Map<ICollection<ExpenseClaimViewModel>>(allExpenseClaims);
            return mappedExpenseClaims.ToList();            
        }

        public async Task<List<ExpenseClaimItemsViewModel>> GetExpenseClaimsWithItems(bool includeHistory)
        {
            //await AddBearerToken();

            var allExpenseClaims = await _client.GetExpenseClaimsWithItemsAsync(includeHistory);
            var mappedExpenseClaims = _mapper.Map<ICollection<ExpenseClaimItemsViewModel>>(allExpenseClaims);
           
            return mappedExpenseClaims.ToList();
        }

        public async Task<ExpenseClaimDetailViewModel> GetExpenseClaimById(int id)
        {
            var selectedtExpenseClaim = await _client.GetExpenseClaimByIdAsync(id);
            var mappedtExpenseClaim = _mapper.Map<ExpenseClaimDetailViewModel>(selectedtExpenseClaim);

            return mappedtExpenseClaim;
        }

        public async Task<ApiResponse<int>> CreateExpenseClaim(ExpenseClaimDetailViewModel expenseClaimDetailViewModel)
        {
            try
            {
                CreateExpenseClaimCommand createExpenseClaimCommand = _mapper.Map<CreateExpenseClaimCommand>(expenseClaimDetailViewModel);
                var newId = await _client.AddExpenseClaimAsync(createExpenseClaimCommand);
                return new ApiResponse<int>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateExpenseClaim(ExpenseClaimDetailViewModel expenseClaimDetailViewModel)
        {            
            try
            {
                UpdateExpenseClaimCommand updateExpenseClaimCommand = _mapper.Map<UpdateExpenseClaimCommand>(expenseClaimDetailViewModel);
                await _client.UpdateExpenseClaimAsync(updateExpenseClaimCommand);
                return new ApiResponse<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> DeleteExpenseClaim(int id)
        {
            try
            {
                await _client.DeleteExpenseClaimAsync(id);
                return new ApiResponse<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
