using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using FinanceServ.DAL.Contexts;

namespace FinanceServ.DAL.Bootstrapping
{
    /// <summary>
    /// Конфигурация БД.
    /// </summary>
    public static class DbConfigurations
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            var stringBuilder = new NpgsqlConnectionStringBuilder(
                configuration.GetConnectionString(nameof(FinanceServContext)));
            stringBuilder.Password = configuration["DbPassword"];
            stringBuilder.Database = configuration["DbName"];

            services.AddDbContext<FinanceServContext>(
                options => options.UseNpgsql(
                    stringBuilder.ConnectionString,
                    builder =>
                    {
                        builder.MigrationsAssembly(typeof(FinanceServContext).Assembly.FullName);
                    })
                );
        }
    }
}
