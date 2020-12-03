using FinanceServ.DAL.Entities;
using System.Collections.Generic;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Акция на фондовом рынке; DTO для <see cref="Stock"/>.
    /// </summary>
    public class StockDto : BaseDto
    {
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
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
