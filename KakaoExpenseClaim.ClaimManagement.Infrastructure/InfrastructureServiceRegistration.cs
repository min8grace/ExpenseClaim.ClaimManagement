using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Application.Models.Mail;
using KakaoExpenseClaim.ClaimManagement.Infrastructure.FileExport;
using KakaoExpenseClaim.ClaimManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KakaoExpenseClaim.ClaimManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
