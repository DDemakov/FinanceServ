using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Акции).
    /// </summary>
    public class StockProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="StockProfile"/>.
        /// </summary>
        public StockProfile()
        {
            CreateMap<Stock, StockDto>().ReverseMap();
        }
    }
}
