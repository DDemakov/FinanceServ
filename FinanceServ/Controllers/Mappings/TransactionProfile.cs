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
            CreateMap<TransactionDto, TransactionResponse>();
            CreateMap<TransactionDto, TransactionSideResponse>();
        }
    }
}
