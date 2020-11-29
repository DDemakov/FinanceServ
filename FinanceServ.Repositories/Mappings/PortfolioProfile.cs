using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Финансовый портфель).
    /// </summary>
    public class PortfolioProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="PortfolioProfile"/>.
        /// </summary>
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioDto>().ReverseMap();
        }
    }
}
