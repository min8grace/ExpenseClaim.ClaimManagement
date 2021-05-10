using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
        
    }
}
