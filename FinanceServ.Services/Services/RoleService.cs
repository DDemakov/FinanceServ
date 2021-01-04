﻿using System;
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
    /// Сервис для работы с ролями.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="RoleService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<RoleDto> CreateAsync(RoleDto dto)
        {
            using var scope = await _unitOfWork.RoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var portfolio = await _unitOfWork.RoleRepository.CreateAsync(dto);
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
        public async Task<IEnumerable<RoleDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.RoleRepository.GetAsync(token: token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<RoleDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.RoleRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<RoleDto> UpdateAsync(RoleDto dto)
        {
            using var scope = await _unitOfWork.RoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var currency = await _unitOfWork.RoleRepository.UpdateAsync(dto);
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
            using var scope = await _unitOfWork.RoleRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.RoleRepository.DeleteAsync(ids);
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
