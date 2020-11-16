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
            services.AddTransient<IStockService, StockService>();
        }
    }
}
