using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;

namespace KakaoExpenseClaim.ClaimManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemListVm>().ReverseMap();
            CreateMap<Item, ItemDetailVm>().ReverseMap();

            CreateMap<ExpenseClaim, ExpenseClaimDto>();
        }
    }
}
