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
    /// Сервис для работы с данными по акциям.
    /// </summary>
    public class StockService : IStockService 
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StockService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<StockDto> CreateAsync(StockDto dto)
        {
            using var scope = await _unitOfWork.StockRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var stock = await _unitOfWork.StockRepository.CreateAsync(dto);
                scope.Commit();
                return stock;
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<StockDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.StockRepository.GetAsync(token: token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<StockDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.StockRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<StockDto> UpdateAsync(StockDto dto)
        {
            using var scope = await _unitOfWork.StockRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var stock = await _unitOfWork.StockRepository.UpdateAsync(dto);
                scope.Commit();
                return stock;
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
            using var scope = await _unitOfWork.StockRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.StockRepository.DeleteAsync(ids);
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
