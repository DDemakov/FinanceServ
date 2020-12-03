using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Базовый класс для моделей сущностей.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
