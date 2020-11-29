using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories.Bootstrapping
{
    /// <summary>
    /// Расширения для конфигурации репозиториев.
    /// </summary>
    public static class RepositoriesConfiguration
    {
        /// <summary>
        /// Конфигурирование репозиториев.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureRepositories (this IServiceCollection services)
        {
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
