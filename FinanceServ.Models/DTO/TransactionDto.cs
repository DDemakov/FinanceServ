using System;
using FinanceServ.DAL.Entities;
using FinanceServ.DAL.Enums;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Финансовая транзакция по покупке/продаже акций; DTO для <see cref="Transaction"/>
    /// </summary>
    public class TransactionDto : BaseDto
    {
        /// <summary>
        /// Тип операции с акциями.
        /// </summary>
        public OperationType Type { get; set; }

        /// <summary>
        /// Дата совершения транзакции.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата добавления транзакции в базу данных.
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Цена акции при выполнении транзакции.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Количество акций в транзакции.
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Идентификатор записи акции, участвовавшей в транзакции.
        /// </summary>
        public long StockId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор пользователя.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор финансового портфеля.
        /// </summary>
        public long PortfolioId { get; set; }

        /// <summary>
        /// Внешний ключ-указатель на идентификатор валюты.
        /// </summary>
        public long CurrencyId { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public CurrencyDto Currency { get; set; }

        /// <summary>
        /// Акция.
        /// </summary>
        public StockDto Stock { get; set; }
    }
}
