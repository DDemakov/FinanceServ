﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Финансовый портфель пользователя.
    /// </summary>
    public class Portfolio : BaseEntity
    {
        /// <summary>
        /// Название финансового портфеля.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Время добавления портфеля в базу данных.
        /// </summary>
        public DateTime Added { get; set; }

        [Required]
        /// <summary>
        /// Идентификатор пользователя, создавшего портфель.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}
