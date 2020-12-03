using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Currency
{
    /// <summary>
    /// Запрос на изменение валюты.
    /// </summary>
    public class UpdateCurrencyRequest : CreateCurrencyRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
