using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Транзакция".
    /// </summary>
    public class TransactionRepository : BaseRepository<TransactionDto, Transaction>, ITransactionRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public TransactionRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
