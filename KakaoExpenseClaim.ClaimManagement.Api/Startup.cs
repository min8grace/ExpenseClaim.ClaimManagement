using KakaoExpenseClaim.ClaimManagement.Application;
using KakaoExpenseClaim.ClaimManagement.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Persistence;
using KakaoExpenseClaim.ClaimManagement.Api.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(ApplicationBuilder => ApplicationBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                //options.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                //      Enter 'Bearer' [space] and then your token in the text input below.
                //      \r\n\r\nExample: 'Bearer 12345abcdef'",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //  {
                //    {
                //      new OpenApiSecurityScheme
                //      {
                //        Reference = new OpenApiReference
                //          {
                //            Type = ReferenceType.SecurityScheme,
                //            Id = "Bearer"
                //          },
                //          Scheme = "oauth2",
                //          Name = "Bearer",
                //          In = ParameterLocation.Header,

                //        },
                //        new List<string>()
                //      }
                //    });

                //services.AddSwaggerGen(c =>
                //{
                //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "KakaoExpenseClaim.ClaimManagement.Api", Version = "v1" });
                //});


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "KakaoExpenseClaim.ClaimManagement.Api",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KakaoExpenseClaim.ClaimManagement.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}