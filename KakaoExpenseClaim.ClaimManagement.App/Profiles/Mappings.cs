using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.App.Services;
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
            // basically from left to right
            // with REverseMap(), from right to left
            CreateMap<CategoryViewModel, CategoryListVm>().ReverseMap();
            CreateMap<CurrencyViewModel, CurrencyListVm>().ReverseMap();

            CreateMap<ExpenseClaimViewModel, ExpenseClaimListVm>().ReverseMap();
            CreateMap<ExpenseClaimItemsViewModel, ExpenseClaimItemListVm>().ReverseMap(); 
            CreateMap<ExpenseClaimDetailViewModel, ExpenseClaimDetailVm>().ReverseMap();
            CreateMap<CreateExpenseClaimCommand, ExpenseClaimDetailViewModel>().ReverseMap();
            CreateMap<CreateExpenseClaimCommand, ExpenseClaimViewModel>().ReverseMap();
            CreateMap<UpdateExpenseClaimCommand, ExpenseClaimDetailViewModel>().ReverseMap();

            CreateMap<ItemViewModel, ItemListVm>().ReverseMap();
            CreateMap<ItemDetailViewModel, ItemDetailVm>().ReverseMap();
            CreateMap<CreateItemCommand, ItemDetailViewModel>().ReverseMap();
            CreateMap<UpdateItemCommand, ItemDetailViewModel>().ReverseMap();

            CreateMap<PagedClaimsForMonthVm, PagedClaimForMonthViewModel>().ReverseMap();
            CreateMap<ClaimsForMonthDto, ExpenseClaimItemsViewModel>().ReverseMap();
        }
    }
}
