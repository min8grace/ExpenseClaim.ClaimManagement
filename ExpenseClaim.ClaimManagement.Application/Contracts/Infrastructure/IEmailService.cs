using KakaoExpenseClaim.ClaimManagement.Application.Models.Mail;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
