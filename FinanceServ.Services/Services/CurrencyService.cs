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
    /// Сервис для работы с данными по валютам.
    /// </summary>
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="CurrencyService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<CurrencyDto> CreateAsync(CurrencyDto dto)
        {
            using var scope = await _unitOfWork.CurrencyRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var portfolio = await _unitOfWork.CurrencyRepository.CreateAsync(dto);
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
        public async Task<IEnumerable<CurrencyDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.CurrencyRepository.GetAsync(token: token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<CurrencyDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.CurrencyRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<CurrencyDto> UpdateAsync(CurrencyDto dto)
        {
            using var scope = await _unitOfWork.CurrencyRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var currency = await _unitOfWork.CurrencyRepository.UpdateAsync(dto);
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
            using var scope = await _unitOfWork.CurrencyRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.CurrencyRepository.DeleteAsync(ids);
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
