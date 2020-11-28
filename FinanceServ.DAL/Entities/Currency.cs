﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Валюта расчётов.
    /// </summary>
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Буквенный код валюты.
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// Цифровой код валюты.
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string NumericCode { get; set; }

        /// <summary>
        /// Возможность использования.
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}
