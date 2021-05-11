using Blazored.LocalStorage;
using KakaoExpenseClaim.ClaimManagement.App.Contracts;
using KakaoExpenseClaim.ClaimManagement.App.Services;
using KakaoExpenseClaim.ClaimManagement.App.Services.Base;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            //builder.Services.AddAuthorizationCore();
            //builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            });

            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:5001"));

            builder.Services.AddScoped<ICurrencyDataService, CurrencyDataService>();
            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<IExpenseClaimDataService, ExpenseClaimDataService>();
            builder.Services.AddScoped<IItemDataService, ItemDataService>();
            //builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
