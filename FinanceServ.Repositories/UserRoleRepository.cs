using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces;

using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;

using FinanceServ.Repositories.Interfaces.CRUD;


namespace FinanceServ.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Пользователь-Роль".
    /// </summary>
    public class UserRoleRepository : BaseRepositoryExtended<UserRoleDto, UserRole>, IUserRoleRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UserRoleRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public UserRoleRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<UserRole> DefaultIncludeProperties(DbSet<UserRole> dbSet)
        {
            return dbSet.Include(e => e.Role)
                        .Include(e => e.User);
        }
    }
}
