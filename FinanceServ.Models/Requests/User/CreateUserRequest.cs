using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.User
{
    /// <summary>
    /// Запрос на добавление нового пользователя в систему.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль доступа к аккаунту.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Дата добавления учётной записи в систему.
        /// </summary>
        [Required]
        public DateTime Added { get; set; }

        /// <summary>
        /// Дата последнего изменения учётной записи.
        /// </summary>
        [Required]
        public DateTime Changed { get; set; }
    }
}
