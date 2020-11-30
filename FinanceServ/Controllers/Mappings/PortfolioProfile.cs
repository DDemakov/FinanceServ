using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Portfolio;
using FinanceServ.Models.Responses.Portfolio;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Финансовый портфель".
    /// </summary>
    public class PortfolioProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioProfile"/>.
        /// </summary>
        public PortfolioProfile()
        {
            CreateMap<CreatePortfolioRequest, PortfolioDto>();
            CreateMap<UpdatePortfolioRequest, PortfolioDto>();
            CreateMap<PortfolioDto, PortfolioResponse>();
            CreateMap<PortfolioDto, PortfolioSideResponse>();
        }
    }
}
