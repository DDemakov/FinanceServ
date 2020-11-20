using System;
using System.Collections.Generic;
using System.Text;
using FinanceServ.Models.DTO;

namespace FinanceServ.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными по акциям.
    /// </summary>
    public interface IStockService
    {
        IEnumerable<StockDto> GetStocks();
    }
}
