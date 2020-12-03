using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Contexts.EntitiesConfiguration
{
    /// <summary>
    /// Класс конфигурации сущности "Финансовый портфель".
    /// </summary>
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        /// <summary>
        /// Конфигурирование сущности "Финансовый портфель".
        /// </summary>
        /// <param name="builder">Билдер.</param>
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Portfolios)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
