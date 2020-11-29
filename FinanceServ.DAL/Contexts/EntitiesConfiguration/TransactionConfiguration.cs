using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Contexts.EntitiesConfiguration
{
    /// <summary>
    /// Класс конфигурации сущности "Транзакция".
    /// </summary>
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        /// <summary>
        /// Конфигурирование сущности "Транзакция".
        /// </summary>
        /// <param name="builder">Билдер.</param>
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(t => t.User)
                   .WithMany(u => u.Transactions)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Portfolio)
                   .WithMany(p => p.Transactions)
                   .HasForeignKey(t => t.PortfolioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Stock)
                   .WithMany(s => s.Transactions)
                   .HasForeignKey(t => t.StockId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
