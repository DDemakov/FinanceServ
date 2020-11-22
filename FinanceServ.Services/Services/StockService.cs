using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.DAL.Mocks;
using FinanceServ.Services.Interfaces;

namespace FinanceServ.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными по акциям.
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StockService"/> 
        /// </summary>
        /// <param name="mapper">Маппер.</param>
        public StockService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc cref="IStockService"/>
        public IEnumerable<StockDto> GetStocks()
        {
            var stocks = StockMock.GetStockCollection();
            var stocksDto = _mapper.Map<IEnumerable<StockDto>>(stocks);
            return stocksDto;
        }
    }
}
