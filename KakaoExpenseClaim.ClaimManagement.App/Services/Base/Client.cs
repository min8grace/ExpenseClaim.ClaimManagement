using System.Net.Http;

namespace KakaoExpenseClaim.ClaimManagement.App.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
