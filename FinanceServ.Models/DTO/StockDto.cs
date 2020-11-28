﻿using System;
using System.ComponentModel.DataAnnotations;
using FinanceServ.DAL.Entities;
using System.Collections.Generic;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Акция на фондовом рынке; DTO для <see cref="Stock"/>.
    /// </summary>
    public class StockDto : BaseDto
    {
        /// <summary>
        /// Имя компании.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Тикер компании на бирже (фондовом рынке).
        /// </summary>
        [Required]
        public string Ticker { get; set; }

        /// <summary>
        /// Краткое описание компании.
        /// </summary>
        [MaxLength(1500)]
        public string Description { get; set; }

        /// <summary>
        /// Год основания компании.
        /// </summary>
        [Required]
        public int Foundation { get; set; }

        /// <summary>
        /// Сектор экономики.
        /// </summary>
        [Required]
        public string Sector { get; set; }

        /// <summary>
        /// Область индустрии.
        /// </summary>
        [Required]
        public string Industry { get; set; }

        /// <summary>
        /// Страна расположения компании.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
