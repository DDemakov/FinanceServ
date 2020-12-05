using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Акция на фондовом рынке.
    /// </summary>
    public class Stock : BaseEntity
    {
        /// <summary>
        /// Имя компании.
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Тикер компании на бирже (фондовом рынке).
        /// </summary>
        [Required]
        public string Ticker { get; set; }
       
        /// <summary>
        /// Краткое описание компании.
        /// </summary>
        [StringLength(1500)]
        public string Description { get; set; }
        
        /// <summary>
        /// Год основания компании.
        /// </summary>
        [Required]
        public int Foundation { get; set; }

        /// <summary>
        /// Сектор экономики.
        /// </summary>
        [Required]
        public string Sector { get; set; }

        /// <summary>
        /// Область индустрии.
        /// </summary>
        [Required]
        public string Industry { get; set; }

        /// <summary>
        /// Страна расположения компании.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Связанные транзакции.
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}
