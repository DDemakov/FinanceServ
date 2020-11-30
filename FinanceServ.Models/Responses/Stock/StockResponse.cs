using System;
using System.Collections.Generic;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Models.Responses.Stock
{
    /// <summary>
    /// Ответ на запросы по видам акций.
    /// </summary>
    public class StockResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя компании.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тикер компании на бирже (фондовом рынке).
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Краткое описание компании.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Год основания компании.
        /// </summary>
        public int Foundation { get; set; }

        /// <summary>
        /// Сектор экономики.
        /// </summary>
        public string Sector { get; set; }

        /// <summary>
        /// Область индустрии.
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Страна расположения компании.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionSideResponse> Transactions { get; set; }
    }
}
