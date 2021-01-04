using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Contexts.EntitiesConfiguration
{
    /// <summary>
    /// Класс конфигурации сущности "Роль".
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Конфигурирование сущности "Роль".
        /// </summary>
        /// <param name="builder">Билдер.</param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}
