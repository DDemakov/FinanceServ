using System;
using System.ComponentModel.DataAnnotations;
using FinanceServ.DAL.Entities;
using System.Collections.Generic;
using FinanceServ.DAL.Enums;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Пользователь приложения; DTO для <see cref="User"/>
    /// </summary>
    public class UserDto : BaseDto
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

        /// <summary>
        /// Связанные финансовые портфели.
        /// </summary>
        public ICollection<PortfolioDto> Portfolios { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
