using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Portfolio
{
    /// <summary>
    /// Запрос на создание финансового портфеля.
    /// </summary>
    public class CreatePortfolioRequest
    {
        /// <summary>
        /// Название финансового портфеля.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Время добавления портфеля в базу данных.
        /// </summary>
        [Required]
        public DateTime Added { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего портфель.
        /// </summary>
        [Required]
        public long UserId { get; set; }
    }
}
