using System;
using System.Collections.Generic;
using System.Text;
using FinanceServ.Services.Interfaces;
using FinanceServ.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceServ.Services.Bootstrapping
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Конфигурирование сервисов.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
        }
    }
}
