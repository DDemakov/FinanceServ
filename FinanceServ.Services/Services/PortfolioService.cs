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
        private readonly IPortfolioRepository _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioService"/>
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public PortfolioService(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<PortfolioDto> CreateAsync(PortfolioDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<PortfolioDto>> GetAsync(CancellationToken token = default)
        {
            return await _repository.GetAsync(token);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<PortfolioDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _repository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<PortfolioDto> UpdateAsync(PortfolioDto dto)
        {
            return await _repository.UpdateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }
    }
}
