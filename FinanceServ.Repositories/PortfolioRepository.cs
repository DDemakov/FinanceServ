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
    /// Репозиторий для работы с сущностями "Финансовый портфель".
    /// </summary>
    public class PortfolioRepository : BaseRepositoryExtended<PortfolioDto, Portfolio>, IPortfolioRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public PortfolioRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {

        }

        protected override IQueryable<Portfolio> DefaultIncludeProperties(DbSet<Portfolio> dbSet)
        {
            return dbSet.Include(e => e.Transactions);
        }
    }
}
