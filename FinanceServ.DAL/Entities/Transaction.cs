﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceServ.DAL.Enums;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Финансовая транзакция по покупке/продаже акций.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Тип операции с акциями.
        /// </summary>
        [Required]
        public OperationType Type { get; set; }

        /// <summary>
        /// Дата совершения транзакции.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата добавления транзакции в базу данных.
        /// </summary>
        [Required]
        public DateTime Added { get; set; }

        /// <summary>
        /// Цена акции при выполнении транзакции.
        /// </summary>
        public decimal? Price { get; set; }

        [Required]
        /// <summary>
        /// Количество акций в транзакции.
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Идентификатор записи акции, участвовавшей в транзакции.
        /// </summary>
        [Required]
        public int StockId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор пользователя.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор финансового портфеля.
        /// </summary>
        [Required]
        public int PortfolioId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор валюты.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Акция.
        /// </summary>
        public Stock Stock { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Финансовый портфель.
        /// </summary>
        public Portfolio Portfolio { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public Currency Currency { get; set; }
    }
}
