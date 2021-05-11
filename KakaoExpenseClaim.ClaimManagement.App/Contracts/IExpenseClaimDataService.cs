﻿using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Contracts
{
    public interface IExpenseClaimDataService
    {
        Task<List<ExpenseClaimViewModel>> GetAllExpenseClaims();
        Task<List<ExpenseClaimItemsViewModel>> GetExpenseClaimsWithItems(bool includeHistory);
        Task<ExpenseClaimDetailViewModel> GetExpenseClaimById(int id);
        Task<ApiResponse<ExpenseClaimDto>> CreateExpenseClaim(ExpenseClaimViewModel expenseClaimViewModel);
        Task<ApiResponse<int>> UpdateExpenseClaim(ExpenseClaimDetailViewModel expenseClaimDetailViewModel);
        Task<ApiResponse<int>> DeleteExpenseClaim(int id);

    }
}