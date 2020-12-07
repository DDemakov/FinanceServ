﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Пользователь".
    /// </summary>
    public class UserRepository : BaseRepositoryExtended<UserDto, User>, IUserRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UserRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public UserRepository(FinanceServContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<User> DefaultIncludeProperties(DbSet<User> dbSet)
        {
            return dbSet.Include(e => e.Portfolios);
        }
    }
}
