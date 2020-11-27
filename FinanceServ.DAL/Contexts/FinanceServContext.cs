﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FinanceServ.DAL.Entities;

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
        /// Инициализирует экземпляр <see cref="FinanceServContext"/>.
        /// </summary>
        /// <param name="options">Опции.</param>
        public FinanceServContext(DbContextOptions<FinanceServContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}