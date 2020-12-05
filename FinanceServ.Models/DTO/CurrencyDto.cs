using System.Collections.Generic;
using FinanceServ.DAL.Entities;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Валюта расчётов; DTO для <see cref="Currency"/>.
    /// </summary>
    public class CurrencyDto : BaseDto
    {
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
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
