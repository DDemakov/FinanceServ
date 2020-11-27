using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Финансовый портфель пользователя.
    /// </summary>
    public class Portfolio
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
        public int UserId { get; set; }

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
