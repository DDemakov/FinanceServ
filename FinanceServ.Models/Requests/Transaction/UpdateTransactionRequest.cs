﻿using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Transaction
{
    /// <summary>
    /// Запрос на изменение транзакции.
    /// </summary>
    public class UpdateTransactionRequest : CreateTransactionRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
