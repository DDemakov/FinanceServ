using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Portfolio
{
    /// <summary>
    /// Запрос на изменение финансового портфеля.
    /// </summary>
    public class UpdatePortfolioRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
