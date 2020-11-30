using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Stock;
using FinanceServ.Models.Responses.Stock;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Акции".
    /// </summary>
    public class StockProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="StockProfile"/>.
        /// </summary>
        public StockProfile()
        {
            CreateMap<CreateStockRequest, StockDto>();
            CreateMap<UpdateStockRequest, StockDto>();
            CreateMap<StockDto, StockResponse>();
        }
    }
}
