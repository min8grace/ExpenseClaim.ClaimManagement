using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Categories.Commands.CreateCategory;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Categories.Commands.UpdateCategory;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Categories.Queries.GetCategoriesList;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateCurrency;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.UpdateCurrency;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.UpdateItem;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Queries.GetCurrenciesList;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.UpdateExpenseClaim;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesList;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesListWithEvents;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimById;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;

namespace KakaoExpenseClaim.ClaimManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {


            CreateMap<CreateExpenseClaimCommand, ExpenseClaim>();
            CreateMap<ExpenseClaim, CreateExpenseClaimDto>();
            CreateMap<UpdateExpenseClaimCommand, ExpenseClaim>();
            CreateMap<ExpenseClaim, ExpenseClaimListVm>();
            CreateMap<ExpenseClaim, ExpenseClaimItemListVm>();
            CreateMap<ExpenseClaimsExportDto, ExpenseClaim>();
            CreateMap<ExpenseClaim, ExpenseClaimDetailVm>();

            CreateMap<CreateItemCommand, Item>();
            CreateMap<Item, CreateItemDto>();
            CreateMap<UpdateItemCommand, Item>();
            CreateMap<Item, ItemDetailVm>();
            CreateMap<Item, ItemListVm>();
            CreateMap<ExpenseClaim, ExpenseClaimDto>();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryListVm>();

            CreateMap<CreateCurrencyCommand, Category>();
            CreateMap<UpdateCurrencyCommand, Category>();
            CreateMap<Category, CurrencyListVm>();



        }
    }
}
