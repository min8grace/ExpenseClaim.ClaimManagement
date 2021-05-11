﻿using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App.Services.Base
{
    public class BaseDataService
    {
        protected readonly ILocalStorageService _localStorage;
        
        protected IClient _client;

        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;

        }

        protected ApiResponse<int> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<int>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<int>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<int>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
