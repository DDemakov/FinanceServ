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
    /// Репозиторий для работы с сущностями "Акция".
    /// </summary>
    public class StockRepository : BaseRepositoryExtended<StockDto, Stock>, IStockRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="StockRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public StockRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Stock> DefaultIncludeProperties(DbSet<Stock> dbSet)
        {
            return dbSet.Include(e => e.Transactions);
        }
    }
}
