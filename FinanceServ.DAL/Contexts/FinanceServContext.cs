﻿using Microsoft.EntityFrameworkCore;
using FinanceServ.DAL.Entities;
using FinanceServ.DAL.Contexts.EntitiesConfiguration;

namespace FinanceServ.DAL.Contexts
{
    /// <summary>
    /// Контекст для работы с данными БД финансового сервиса
    /// </summary>
    public class FinanceServContext : DbContext
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Финансовые портфели.
        /// </summary>
        public DbSet<Portfolio> Portfolios { get; set; }

        /// <summary>
        /// Акции.
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Валюты.
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Транзакции.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Роли.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Связевая сущность Пользователь-Роль.
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="FinanceServContext"/>.
        /// </summary>
        /// <param name="options">Опции.</param>
        public FinanceServContext(DbContextOptions<FinanceServContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CurrencyConfiguration());
            builder.ApplyConfiguration(new PortfolioConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
