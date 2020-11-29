using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Stock
{
    /// <summary>
    /// Запрос на изменение акции.
    /// </summary>
    public class UpdateStockRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
