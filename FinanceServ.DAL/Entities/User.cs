using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Пользователь приложения.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль доступа к аккаунту.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Дата добавления учётной записи в систему.
        /// </summary>
        [Required]
        public DateTime Added { get; set; }

        /// <summary>
        /// Дата последнего изменения учётной записи.
        /// </summary>
        [Required]
        public DateTime Changed { get; set; }

        /// <summary>
        /// Связанные финансовые портфели.
        /// </summary>
        public ICollection<Portfolio> Portfolios { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}
