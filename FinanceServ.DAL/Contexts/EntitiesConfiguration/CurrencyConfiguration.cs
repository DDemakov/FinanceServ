using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Contexts.EntitiesConfiguration
{
    /// <summary>
    /// Класс конфигурации сущности "Валюта".
    /// </summary>
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        /// <summary>
        /// Конфигурирование сущности "Валюта".
        /// </summary>
        /// <param name="builder">Билдер.</param>
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasAlternateKey(c => c.AlphabeticCode);
            builder.HasAlternateKey(c => c.NumericCode);
        }
    }
}
