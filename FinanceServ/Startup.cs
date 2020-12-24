using System;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using FinanceServ.Common.Swagger;
using FinanceServ.Services.Bootstrapping;
using FinanceServ.Controllers;
using FinanceServ.Repositories;
using FinanceServ.Repositories.Bootstrapping;
using FinanceServ.DAL.Bootstrapping;
using FinanceServ.Infrastructure;
using FinanceServ.Infrastructure.Interfaces;

namespace FinanceServ
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Метод вызывается средой исполнения. Используется для регистрации сервисов в IoC контейнере.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDb(Configuration);
            services.ConfigureRepositories();
            services.AddControllers();

            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(CurrencyRepository).GetTypeInfo().Assembly,
                typeof(CurrencyController).GetTypeInfo().Assembly);
            services.ConfigureSwagger();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFinanceServ",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200");
                        builder.WithMethods("GET", "POST", "PUT", "OPTIONS");
                        builder.AllowAnyHeader();
                        builder.SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });
        }

        /// <summary>
        /// Mетод вызывается средой исполнения. Используется для конфигурации окружения для обработки HTTP-запроса.
        /// </summary>
        /// <param name="app">Средство конфигурации приложения.</param>
        /// <param name="env">Информация об окружении, в котором работает приложение.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "FinanceService with JWT Authorization V1");
                c.DocumentTitle = "Jwt Authorization";
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseCors("AllowFinanceServ");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
