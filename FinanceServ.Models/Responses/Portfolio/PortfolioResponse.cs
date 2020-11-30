using System;
using System.Collections.Generic;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Models.Responses.Portfolio
{
    /// <summary>
    /// Ответ на запросы по финансовым портфелям.
    /// </summary>
    public class PortfolioResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название финансового портфеля.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Время добавления портфеля в базу данных.
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего портфель.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionSideResponse> Transactions { get; set; }
    }
}
