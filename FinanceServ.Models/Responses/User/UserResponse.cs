using System;
using System.Collections.Generic;
using FinanceServ.Models.Responses.Portfolio;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Models.Responses.User
{
    /// <summary>
    /// Ответ на запросы по пользователям системы.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль доступа к аккаунту.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата добавления учётной записи в систему.
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Дата последнего изменения учётной записи.
        /// </summary>
        public DateTime Changed { get; set; }

        /// <summary>
        /// Связанные финансовые портфели.
        /// </summary>
        public ICollection<PortfolioSideResponse> Portfolios { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionSideResponse> Transactions { get; set; }
    }
}
