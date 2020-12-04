using System.Linq;
using Microsoft.EntityFrameworkCore;
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
    public class TransactionRepository : BaseRepositoryExtended<TransactionDto, Transaction>, ITransactionRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public TransactionRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<Transaction> DefaultIncludeProperties(DbSet<Transaction> dbSet)
        {
            return dbSet.Include(e => e.Stock)
                        .Include(e => e.Currency);
        }
    }
}
