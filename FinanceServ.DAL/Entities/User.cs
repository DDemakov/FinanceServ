using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Пользователь приложения.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
