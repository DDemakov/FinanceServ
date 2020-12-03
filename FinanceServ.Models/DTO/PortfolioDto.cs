using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using FinanceServ.DAL.Entities;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Финансовый портфель пользователя; DTO для <see cref="Portfolio"/>
    /// </summary>
    public class PortfolioDto : BaseDto
    {
        /// <summary>
        /// Название финансового портфеля.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Время добавления портфеля в базу данных.
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего портфель.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
