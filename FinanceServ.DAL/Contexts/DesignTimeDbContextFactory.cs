using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FinanceServ.DAL.Contexts
{
    /// <summary>
    /// Фабрика для создания нового контекста в процессе миграций.
    /// </summary>
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinanceServContext>
    {
        /// <summary>
        /// Создание контекста для миграций.
        /// </summary>
        /// <param name="args">Строковые аргументы миграций.</param>
        /// <returns></returns>
        public FinanceServContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", false, true)
                               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                               true, false)
                               .AddEnvironmentVariables()
                               .Build();

            var connectionString = configuration.GetConnectionString(nameof(FinanceServContext));

            var builder = new DbContextOptionsBuilder<FinanceServContext>()
                .UseNpgsql(connectionString, __options =>
                {
                    __options.MigrationsAssembly(typeof(FinanceServContext).Assembly.FullName);
                });

            var context = new FinanceServContext(builder.Options);

            return context;
        }
    }
}
