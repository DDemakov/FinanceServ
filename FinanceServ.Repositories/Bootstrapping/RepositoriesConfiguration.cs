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
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
