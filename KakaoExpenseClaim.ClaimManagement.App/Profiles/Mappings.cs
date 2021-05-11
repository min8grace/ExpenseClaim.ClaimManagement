using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using KakaoExpenseClaim.ClaimManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CategoryViewModel, CategoryListVm>();
            CreateMap<CurrencyViewModel, CurrencyListVm>();

            CreateMap<ExpenseClaimViewModel, ExpenseClaimListVm>();
            CreateMap<ExpenseClaimItemsViewModel, ExpenseClaimItemListVm>();
            CreateMap<ExpenseClaimDetailViewModel, ExpenseClaimDetailVm>();
            CreateMap<CreateExpenseClaimCommand, ExpenseClaimViewModel>();
            CreateMap<ExpenseClaimDto, CreateExpenseClaimCommandResponse>();
            CreateMap<UpdateExpenseClaimCommand, ExpenseClaimDetailViewModel>();

            CreateMap<ItemViewModel, ItemListVm>();
            CreateMap<ItemDetailViewModel, ItemDetailVm>();
            CreateMap<CreateItemCommand, ItemDetailViewModel>();
            CreateMap<UpdateItemCommand, ItemDetailViewModel>();
        }
    }
}
