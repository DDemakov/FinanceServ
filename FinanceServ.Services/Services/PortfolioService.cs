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
    /// Сервис для работы с данными по финансовым портфелям.
    /// </summary>
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public PortfolioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<PortfolioDto> CreateAsync(PortfolioDto dto)
        {
            using var scope = await _unitOfWork.PortfolioRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var portfolio = await _unitOfWork.PortfolioRepository.CreateAsync(dto);
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
        public async Task<IEnumerable<PortfolioDto>> GetAsync(CancellationToken token = default)
        {
            return await _unitOfWork.PortfolioRepository.GetAsync(token: token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<PortfolioDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _unitOfWork.PortfolioRepository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<PortfolioDto> UpdateAsync(PortfolioDto dto)
        {
            using var scope = await _unitOfWork.PortfolioRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var portfolio = await _unitOfWork.PortfolioRepository.UpdateAsync(dto);
                scope.Commit();
                return portfolio;
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
            using var scope = await _unitOfWork.PortfolioRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _unitOfWork.PortfolioRepository.DeleteAsync(ids);
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
