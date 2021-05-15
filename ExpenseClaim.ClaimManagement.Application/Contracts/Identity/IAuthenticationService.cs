using KakaoExpenseClaim.ClaimManagement.Application.Models.Authentication;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
