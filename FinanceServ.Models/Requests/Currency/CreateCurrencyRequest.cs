using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Currency
{
    /// <summary>
    /// Запрос на создание валюты.
    /// </summary>
    public class CreateCurrencyRequest
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Буквенный код валюты.
        /// </summary>
        [MinLength(3)]
        [MaxLength(3)]
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// Цифровой код валюты.
        /// </summary>
        [MinLength(3)]
        [MaxLength(3)]
        public string NumericCode { get; set; }

        /// <summary>
        /// Возможность использования.
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }
    }
}
