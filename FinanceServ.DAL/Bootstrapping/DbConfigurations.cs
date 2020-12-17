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
            var connectionString = configuration["ConnectionString"];
            var password = configuration["DbPassword"];
            var stringBuilder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = password
            };

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
