using System.Net.Http;

namespace KakaoExpenseClaim.ClaimManagement.App.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
