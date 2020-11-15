﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Акция на фондовом рынке
    /// </summary>
    public class StockDto
    {
        /// <summary>
        /// Имя компании
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Тикер компании на бирже (фондовом рынке)
        /// </summary>
        [Required]
        public string Ticker { get; set; }

        /// <summary>
        /// Краткое описание компании
        /// </summary>
        [MaxLength(1500)]
        public string Description { get; set; }

        /// <summary>
        /// Год основания компании
        /// </summary>
        [Required]
        public int Foundation { get; set; }
    }
}
