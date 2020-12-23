using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces.CRUD;

namespace FinanceServ.Repositories
{
    /// <summary>
    /// Базовый класс репозитория для работы с CRUD.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public class BaseRepository<TDto, TEntity> : ICrudRepository<TDto, TEntity>
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        public FinanceServContext Context { get; }
        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseRepository{TDto, TEntity}"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        protected BaseRepository(FinanceServContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        /// <inheritdoc cref="ICreatable{TDto, TEntity}.CreateAsync(TDto)"/>
        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            
            return await GetAsync(entity.Id);
        }

        /// <inheritdoc cref="IGettableById{TDto, TEntity}.GetAsync(long)"/>
        public async Task<TDto> GetAsync(long id)
        {
            var entity = await DbSet
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);

            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="IGettable{TDto, TEntity}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<TDto>> GetAsync(bool isCollectionWithIncludes = false, CancellationToken token = default)
        {
            var entities = await DbSet.AsNoTracking().ToListAsync();

            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }

        /// <inheritdoc cref="IUpdatable{TDto, TEntity}.UpdateAsync(TDto, CancellationToken)(TDto)"/>
        public async Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default)
        {
            var entity = _mapper.Map<TEntity>(dto);
            Context.Update(entity);
            await Context.SaveChangesAsync(token);

            var newEntity = await GetAsync(entity.Id);

            return _mapper.Map<TDto>(newEntity);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            var entities = await DbSet
                                .Where(x => ids.Contains(x.Id))
                                .ToListAsync();

            Context.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}
