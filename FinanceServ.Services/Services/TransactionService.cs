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
    /// Сервис для работы с данными по транзакциям.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<TransactionDto> CreateAsync(TransactionDto dto)
        {
            using var scope = await _unitOfWork.TransactionRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var finTransaction = await _unitOfWork.TransactionRepository.CreateAsync(dto);
                scope.Commit();
                return finTransaction;
            }

            catch (Exception e)
            {
                scope.Rollback();
                throw e;
            }
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<TransactionDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.TransactionRepository.GetAsync(token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<TransactionDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.TransactionRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<TransactionDto> UpdateAsync(TransactionDto dto)
        {
            using var scope = await _unitOfWork.TransactionRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var finTransaction = await _unitOfWork.TransactionRepository.UpdateAsync(dto);
                scope.Commit();
                return finTransaction;
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
            using var scope = await _unitOfWork.TransactionRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.TransactionRepository.DeleteAsync(ids);
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
