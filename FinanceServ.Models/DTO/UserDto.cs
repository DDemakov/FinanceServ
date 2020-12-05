using System;
using System.Collections.Generic;
using FinanceServ.DAL.Entities;

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
        public string Email { get; set; }

        /// <summary>
        /// Пароль доступа к аккаунту.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата добавления учётной записи в систему.
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Дата последнего изменения учётной записи.
        /// </summary>
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
