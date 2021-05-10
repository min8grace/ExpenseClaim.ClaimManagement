using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
