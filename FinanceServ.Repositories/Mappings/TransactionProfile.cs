using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Транзакция).
    /// </summary>
    public class TransactionProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="TransactionProfile"/>.
        /// </summary>
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
