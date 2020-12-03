using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServ.Models.Responses.Portfolio
{
    /// <summary>
    /// Ответ для связанных запросов по пользовательским финансовым портфелям.
    /// </summary>
    public class PortfolioSideResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

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
    }
}
