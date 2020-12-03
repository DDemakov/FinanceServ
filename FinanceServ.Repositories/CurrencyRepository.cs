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
    /// Репозиторий для работы с сущностями "Валюта".
    /// </summary>
    public class CurrencyRepository : BaseRepositoryExtended<CurrencyDto, Currency>, ICurrencyRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="CurrencyRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public CurrencyRepository(FinanceServContext context, IMapper mapper) : base (context, mapper)
        {
        }

        protected override IQueryable<Currency> DefaultIncludeProperties(DbSet<Currency> dbSet)
        {
            return dbSet.Include(e => e.Transactions);
        }
    }
}
