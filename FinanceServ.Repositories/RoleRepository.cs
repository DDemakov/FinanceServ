using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Роль".
    /// </summary>
    public class RoleRepository : BaseRepositoryExtended<RoleDto, Role>, IRoleRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="RoleRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public RoleRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
