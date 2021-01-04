using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Contexts.EntitiesConfiguration
{
    /// <summary>
    /// Класс конфигурации сущности "Акция".
    /// </summary>
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        /// <summary>
        /// Конфигурирование сущности "Акция".
        /// </summary>
        /// <param name="builder">Билдер.</param>
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasIndex(s => s.Ticker)
                .IsUnique();
        }
    }
}
