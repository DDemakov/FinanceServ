using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServ.DAL.Entities
{
    /// <summary>
    /// Акция на фондовом рынке
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Имя компании
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Тикер компании на бирже (фондовом рынке)
        /// </summary>
        public string Ticker { get; set; }
       
        /// <summary>
        /// Краткое описание компании
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Год основания компании
        /// </summary>
        public int Foundation { get; set; }
    }
}
