using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<FinanceServContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString(nameof(FinanceServContext)),
                    builder => builder.MigrationsAssembly(typeof(FinanceServContext).Assembly.FullName))
                );
        }
    }
}
