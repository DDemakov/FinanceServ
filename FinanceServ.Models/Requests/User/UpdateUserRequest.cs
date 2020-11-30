using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.User
{
    /// <summary>
    /// Запрос на изменение пользователя.
    /// </summary>
    public class UpdateUserRequest : CreateUserRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
