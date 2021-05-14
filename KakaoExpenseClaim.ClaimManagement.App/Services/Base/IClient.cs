using System.Net.Http;

namespace KakaoExpenseClaim.ClaimManagement.App.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
