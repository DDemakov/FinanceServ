using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Валюта).
    /// </summary>
    public class CurrencyProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="CurrencyProfile"/>.
        /// </summary>
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDto>().ReverseMap();
        }
    }
}
