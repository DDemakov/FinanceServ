using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Stock
{
    /// <summary>
    /// Запрос на изменение акции.
    /// </summary>
    public class UpdateStockRequest : CreateStockRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
