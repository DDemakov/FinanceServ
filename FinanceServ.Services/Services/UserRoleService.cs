using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces;
using FinanceServ.Repositories.Interfaces;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Services
{
    /// <summary>
    /// Сервис для работы с сущностями пользователь-роль.
    /// </summary>
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserRoleService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<UserRoleDto> CreateAsync(UserRoleDto dto)
        {
            using var scope = await _unitOfWork.UserRoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var portfolio = await _unitOfWork.UserRoleRepository.CreateAsync(dto);
                scope.Commit();
                return portfolio;
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<UserRoleDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.UserRoleRepository.GetAsync(token: token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<UserRoleDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.UserRoleRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<UserRoleDto> UpdateAsync(UserRoleDto dto)
        {
            using var scope = await _unitOfWork.UserRoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var currency = await _unitOfWork.UserRoleRepository.UpdateAsync(dto);
                scope.Commit();
                return currency;
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(long[] ids)
        {
            using var scope = await _unitOfWork.UserRoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.UserRoleRepository.DeleteAsync(ids);
                scope.Commit();
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }
    }
}
