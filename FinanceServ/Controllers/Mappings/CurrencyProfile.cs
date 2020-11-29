using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Currency;
using FinanceServ.Models.Responses.Currency;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Валюта".
    /// </summary>
    public class CurrencyProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="CurrencyProfile"/>.
        /// </summary>
        public CurrencyProfile()
        {
            CreateMap<CreateCurrencyRequest, CurrencyDto>();
            CreateMap<UpdateCurrencyRequest, CurrencyDto>();
            CreateMap<CurrencyDto, CurrencyResponse>();
        }
    }
}
