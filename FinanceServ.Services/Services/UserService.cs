﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces;
using FinanceServ.Repositories.Interfaces;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными по пользователям.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit of Work.</param>
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<UserDto> CreateAsync(UserDto dto)
        {
            using var scope = await _unitOfWork.UserRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.UserRepository.CreateAsync(dto);
                scope.Commit();
                return user;
            }

            catch(Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<UserDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.UserRepository.GetAsync(token : token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<UserDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.UserRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<UserDto> UpdateAsync(UserDto dto)
        {
            using var scope = await _unitOfWork.UserRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.UserRepository.UpdateAsync(dto);
                scope.Commit();
                return user;
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
            using var scope = await _unitOfWork.UserRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.UserRepository.DeleteAsync(ids);
                scope.Commit();
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }


        /// <inheritdoc cref="IUserService.IsAnExistingUserAsync(string)"/>
        public async Task<bool> IsAnExistingUserAsync(string email)
        {
            var users = await _unitOfWork.UserRepository.GetAsync();
            return users.Any(x => x.Email == email);
        }

        /// <inheritdoc cref="IUserService.IsValidUserCredentials(string, string)"/>
        public async Task<bool> IsValidUserCredentialsAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var users = await _unitOfWork.UserRepository.GetAsync();
            return users.Any(x => x.Email == email && x.Password == password);
        }

        /// <inheritdoc cref="IUserService.GetUserRole(string)"/>
        public async Task<string> GetUserRoleAsync(string email)
        {
            var isUserExist = await IsAnExistingUserAsync(email);
            
            if (!isUserExist)
            {
                return string.Empty;
            }

            var roles = await _unitOfWork.UserRoleRepository.GetAsync(true);
            var role = roles.SingleOrDefault(x => x.User.Email == email).Role?.Name;

            if (string.IsNullOrEmpty(role))
                throw new ArgumentNullException("Не могу найти роль, сопоставленную пользователю");

            return role;
        }
    }
}
