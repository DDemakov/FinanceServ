using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using FinanceServ.DAL.Entities;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Валюта расчётов; DTO для <see cref="Currency"/>.
    /// </summary>
    public class CurrencyDto
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Буквенный код валюты.
        /// </summary>
        [MinLength(3)]
        [MaxLength(3)]
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// Цифровой код валюты.
        /// </summary>
        [MinLength(3)]
        [MaxLength(3)]
        public string NumericCode { get; set; }

        /// <summary>
        /// Возможность использования.
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
