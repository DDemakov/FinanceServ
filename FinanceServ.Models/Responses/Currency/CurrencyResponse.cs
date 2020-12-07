using System.Collections.Generic;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Models.Responses.Currency
{
    /// <summary>
    /// Ответ на запросы по видам валют.
    /// </summary>
    public class CurrencyResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Буквенный код валюты.
        /// </summary>
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// Цифровой код валюты.
        /// </summary>
        public string NumericCode { get; set; }

        /// <summary>
        /// Краткое описание валюты.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Возможность использования.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionSideResponse> Transactions { get; set; }
    }
}
