using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Transaction;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Транзакция".
    /// </summary>
    public class TransactionProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionProfile"/>.
        /// </summary>
        public TransactionProfile()
        {
            CreateMap<CreateTransactionRequest, TransactionDto>();
            CreateMap<UpdateTransactionRequest, TransactionDto>();
            CreateMap<TransactionDto, TransactionResponse>()
                .ForMember(x => x.StockTicker, y => y.MapFrom(src => src.Stock.Ticker))
                .ForMember(x => x.CurrencyAlphabeticCode, y => y.MapFrom(src => src.Currency.AlphabeticCode));
            CreateMap<TransactionDto, TransactionSideResponse>();
        }
    }
}
